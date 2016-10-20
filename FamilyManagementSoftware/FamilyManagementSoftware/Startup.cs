using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyManagementSoftware.Startup))]
namespace FamilyManagementSoftware
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
