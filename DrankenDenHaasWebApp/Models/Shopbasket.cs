using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp.Models

{
    //Deze klasse heb ik niet als tabel in de databank omdat een winkelmandje iets tijdelijk is, 
    //en niet moet opgeslagen worden in een databank.
    
    public class Shopbasket
    {
        public static List<Shopbasket> winkelmandje = new List<Shopbasket>();

        //public static void VoegProptoe ( int id, string naam, int aantal, decimal prijs)
        //{
        //    Shopbasket a1 = new Shopbasket { Id = id, ProductNaam = naam, Aantal = aantal, Prijs = prijs };
        //    winkelmandje.Add(a1);

        //}



        //public List<Shopbasket> uniekmandje = (List<Shopbasket>)Session["Winkelmand"]; 

        public static void VoegToe(Shopbasket shopbasket)
        {
            winkelmandje.Add(shopbasket); 
        }

        [Display(Name = "")]
        public string ImagePath { get; set; }

        [Display(Name = "PriceItem", ResourceType = typeof(Texts))]
        public decimal Prijs { get; set; }

        [Display(Name = "Amount", ResourceType = typeof(Texts))]
        public int Aantal { get; set; }

        [Display(Name = "ProductName", ResourceType = typeof(Texts))]
        public string ProductNaam { get; set; }

        public int Id { get; set; }

        public static Shopbasket Find(int? Id)
        {

            if (Id != null)
                foreach (Shopbasket c in winkelmandje)
                    if (c.Id == Id)
                        return c;
            return null;
        }

    }

    public class ShopbasketViewModel
    {


    }
}