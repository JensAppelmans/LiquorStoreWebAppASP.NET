using DrankenDenHaasWebApp.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrankenDenHaasWebApp.Startup))]
namespace DrankenDenHaasWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Language.Initialize();
            ConfigureAuth(app);


            


        }
    }
}
