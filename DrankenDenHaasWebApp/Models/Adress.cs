using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp

{
    public partial class Adress
    {
        public Adress()
        {
        }

        public Adress(AdressViewModel model)
        {
            AdresId = model.AdresId;
            Land = model.Land;
            Provincie = model.Provincie;
            Stad = model.Stad;
            Postcode = model.Postcode;
            Straatnaam = model.Straatnaam;
            Nummer_Bus = model.Nummer_Bus;
            UserId = model.UserId; 
        }
    }

    public class AdressViewModel
    {
        /* 
         -Een user moet alleen zijn eigen adres kunnen opvragen en aanpassen in via de account manager. 
         
         -Een admin moet de adresgegevens van alle users kunnen zien, index van alle adressen.
         de admin zal ook geen adressen moeten aanmaken, aangezien de webapp alles moet automatiseren 
         en de user zelf zijn adres moet invullen en aanpassen. (only webshop)
         
         */

        public int AdresId { get; set; } //wordt automatisch ingevuld in database

        [Required]
        public string Land { get; set; }

        [Required]
        public string Provincie { get; set; }

        [Required]
        public string Stad { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Straatnaam { get; set; }

        [Required]
        [Display(Name = "Nummer of bus")]
        public string Nummer_Bus { get; set; }

        public string UserId { get; set; } //Ophalen van user die ingelogd is!

        public AdressViewModel(Adress model)
        {
            AdresId = model.AdresId;
            Land = model.Land;
            Provincie = model.Provincie;
            Stad = model.Stad;
            Postcode = model.Postcode;
            Straatnaam = model.Straatnaam;
            Nummer_Bus = model.Nummer_Bus;
            UserId = model.UserId;
        }

        public AdressViewModel()
        {

        }
    }
}