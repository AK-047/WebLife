using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLife.Startup))]
namespace WebLife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
