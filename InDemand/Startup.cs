using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InDemand.Startup))]
namespace InDemand
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
