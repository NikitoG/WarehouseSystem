using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarehouseSystem.Web.Startup))]
namespace WarehouseSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
