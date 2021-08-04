using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MC.ContactLessDining.Startup))]
namespace MC.ContactLessDining
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
