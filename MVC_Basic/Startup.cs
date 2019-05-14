using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Basic.Startup))]
namespace MVC_Basic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
