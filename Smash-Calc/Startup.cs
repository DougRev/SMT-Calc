using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Smash_Calc.Startup))]
namespace Smash_Calc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
