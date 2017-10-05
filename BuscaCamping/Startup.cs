using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuscaCamping.Startup))]
namespace BuscaCamping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
