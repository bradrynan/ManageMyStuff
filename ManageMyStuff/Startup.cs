using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageMyStuff.Startup))]
namespace ManageMyStuff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
