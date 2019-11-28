using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeDetails.Startup))]
namespace EmployeeDetails
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
