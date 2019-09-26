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
            //Shopbasket a1 = new Shopbasket { Aantal = 2, Id = 1, Prijs = 20, ProductNaam = "duvel" };

            //Shopbasket a2 = new Shopbasket { Aantal = 2, Id = 2, Prijs = 20, ProductNaam = "leffe" };

            //Shopbasket a3 = new Shopbasket { Aantal = 2, Id = 3, Prijs = 20, ProductNaam = "Orval" };

            //Shopbasket a4 = new Shopbasket { Aantal = 2, Id = 4, Prijs = 20, ProductNaam = "Cola" };
            //Shopbasket.VoegToe(a1);
            //Shopbasket.VoegToe(a2);
            //Shopbasket.VoegToe(a3);
            //Shopbasket.VoegToe(a4);
            ConfigureAuth(app);


            


        }
    }
}
