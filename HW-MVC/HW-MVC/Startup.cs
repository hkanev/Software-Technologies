using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HW_MVC.Startup))]
namespace HW_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
