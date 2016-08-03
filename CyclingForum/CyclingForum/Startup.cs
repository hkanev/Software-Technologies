using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CyclingForum.Startup))]
namespace CyclingForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
