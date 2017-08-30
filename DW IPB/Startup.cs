using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DW_IPB.Startup))]
namespace DW_IPB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
