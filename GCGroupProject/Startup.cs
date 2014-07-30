using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCGroupProject.Startup))]
namespace GCGroupProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
