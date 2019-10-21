using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TSG_Blog.Startup))]
namespace TSG_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
