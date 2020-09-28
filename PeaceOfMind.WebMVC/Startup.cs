using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeaceOfMind.WebMVC.Startup))]
namespace PeaceOfMind.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
