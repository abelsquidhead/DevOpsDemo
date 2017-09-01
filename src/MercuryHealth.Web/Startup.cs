using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MercuryHealth.Web.Startup))]
namespace MercuryHealth.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
