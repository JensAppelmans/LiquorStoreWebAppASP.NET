using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp
{
    public partial class Orders_Products
    {
        public Orders_Products()
        {

        }

        public Orders_Products(Order_ProductsViewModel model)
        {
            BestelId = model.BestelId;
            ProductId = model.ProductId;
            Aantal = model.Aantal;
            Prijs_Item = model.Prijs_Item;
            Subtotaal = model.Subtotaal;
        }
    }

    public class Order_ProductsViewModel
    {
        /* Wanneer een user een bepaalde bestelling kiest, moet deze meer info krijgen over de inhoud van de
         bestelling, zoals welke items en het aantal van een bepaald item. Mag geen aanpassingen kunnen doen.
         
         De admin moet dit ook kunnen en mag ook geen aanpassingen kunnen doen.
         
         
         
        */

        [Display(Name = "")]
        public string ImagePath { get; set; }

        [Display(Name = "OrderId", ResourceType = typeof(Texts))]
        public int BestelId { get; set; }

        [Display(Name = "ProductId", ResourceType = typeof(Texts))]
        public int ProductId { get; set; }

        [Display(Name = "Amount", ResourceType = typeof(Texts))]
        public int Aantal { get; set; }

        
        [Display(Name = "PriceItem", ResourceType = typeof(Texts))]
        public decimal Prijs_Item { get; set; }

        [Display(Name = "SubTotal", ResourceType = typeof(Texts))]
        public decimal Subtotaal { get; set; }

        [Display(Name = "ProductName", ResourceType = typeof(Texts))]
        public string  Productnaam { get; set; }

        
        public Order_ProductsViewModel()
        {

        }

        public Order_ProductsViewModel(Orders_Products model)
        {
            BestelId = model.BestelId;
            ProductId = model.ProductId;
            Aantal = model.Aantal;
            Prijs_Item = model.Prijs_Item;
            Subtotaal = model.Subtotaal;
            Productnaam = model.Product.Productnaam;

            using (DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities())
            {

                var query = db.Multimedias.Where(p => p.ProductId == ProductId);

                string absPath = query.First().ImagePath;
                string relPath = Path.GetFileName(absPath);
                ImagePath = "~/Afbeeldingen/" + relPath;
            }
            }


    }
}