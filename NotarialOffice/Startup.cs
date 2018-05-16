using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotarialOffice.Startup))]
namespace NotarialOffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
