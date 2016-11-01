using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyRPLku.Startup))]
namespace StudyRPLku
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
