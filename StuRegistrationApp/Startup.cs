using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StuRegistrationApp.Startup))]
namespace StuRegistrationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
