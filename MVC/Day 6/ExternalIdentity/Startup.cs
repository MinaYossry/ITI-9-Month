using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExternalIdentity.Startup))]
namespace ExternalIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
