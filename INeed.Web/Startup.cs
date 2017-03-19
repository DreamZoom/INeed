using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INeed.Web.Startup))]
namespace INeed.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
