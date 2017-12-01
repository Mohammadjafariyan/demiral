using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demiral.Startup))]
namespace Demiral
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
