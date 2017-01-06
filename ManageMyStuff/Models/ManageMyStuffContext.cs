using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManageMyStuff.Models
{
    public class ManageMyStuffContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ManageMyStuffContext() : base("name=ManageMyStuffContext")
        {
        }

        public System.Data.Entity.DbSet<ManageMyStuff.Models.Webpage> Webpages { get; set; }

        public System.Data.Entity.DbSet<ManageMyStuff.Models.Photo> Photos { get; set; }
    }
}
