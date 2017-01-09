using ManageMyStuff.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types

namespace ManageMyStuff.Controllers
{
    public class HomeController : Controller
    {
        private ManageMyStuffContext db = new ManageMyStuffContext();

        public ActionResult Index(string filter = null, int page = 1, int pageSize = 20)
        {
            var records = new PagedList<Photo>();
            ViewBag.filter = filter;

            records.Content = db.Photos
                        .Where(x => filter == null || (x.Description.Contains(filter)))
                        .OrderByDescending(x => x.PhotoId)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Photos
                            .Where(x => filter == null || (x.Description.Contains(filter))).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var photo = new Photo();
            return View(photo);
        }

        private void SaveToFolder(HttpPostedFileBase file, Photo photo)
        {
            // Retrieve storage account from connection string.
             CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("managemystuffphotos");

            // Retrieve reference to a blob named "photo1.jpg".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

            photo.ImagePath = blockBlob.Uri.ToString();

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = file.InputStream)
            {
                blockBlob.UploadFromStream(fileStream);
            }

            // blockBlob.DownloadToStream(file.InputStream);
        }



        private void ListBlobs()
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("managemystuffphotos");

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blob.DeleteIfExists();

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;
                }


            }
        }

        private void DeleteBlobs()
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("managemystuffphotos");

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blob.DeleteIfExists();

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;
                }
            }
        }


        [HttpPost]
        public ActionResult Create(Photo photo, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
                return View(photo);
            if (files.Count() == 0 || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";
                return View(photo);
            }

            DateTime dtSALDBMin = new DateTime(1753, 1, 1);
            var model = new Photo();
            foreach (var file in files)
            {
                if (file.ContentLength == 0) continue;

                model.Description = photo.Description;
                var fileName = Guid.NewGuid().ToString();
                var extension = System.IO.Path.GetExtension(file.FileName).ToLower();
                FileInfo fi = new FileInfo(file.FileName);
                model.UploadFileName = fi.Name;
                model.FileName = fi.Name;
                model.CreatedOn = fi.LastWriteTime > dtSALDBMin ? fi.LastWriteTime: dtSALDBMin;
                model.TakenBy = Environment.UserName;

                SaveToFolder(file, model);

                // Save record to database
                db.Photos.Add(model);
                db.SaveChanges();
            }

            return RedirectPermanent("/home");
        }

    }
}