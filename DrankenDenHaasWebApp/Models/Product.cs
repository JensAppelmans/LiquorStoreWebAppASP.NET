using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO; 
using DrankenDenHaasWebApp.Translations;

namespace DrankenDenHaasWebApp
{
    public partial class Product
    {
        //public string Categorienaam { get; set; }
        //public string Producentnaam { get; set; }

        public Product(ProductViewModel model)
        {
            ProductId = model.ProductId;
            Productnaam = model.Productnaam;
            Prijs = model.Prijs;
            Beschrijving = model.Beschrijving;
            CategorieId = model.CategorieId;
            AlcoholPercentage___ = model.AlcoholPercentage___;
            Inhoud_cl_ = model.Inhoud_cl_;
            ProducentId = model.ProducentId;
            VerkochtPer = model.VerkochtPer;
            //Categorienaam = model.Categorienaam;
            //Producentnaam = model.Producentnaam;
        }
    }


    public class ProductViewModel
    {
        /*Een user moet een overzicht krijgen van de producten op basis van categorie of producent, 
          Alsook bij het aanklikken meer details krijgen van een bepaald product en de mogelijkheid om het aan te kopen.
          
         Een admin of verkoper moet producten kunnen toevoegen of verwijderen. 
         
         */


        [Display(Name = "CategoryName", ResourceType = typeof(Texts))]
        public string Categorienaam { get; set; }
        [Display(Name = "ProducerName", ResourceType = typeof(Texts))]
        public string Producentnaam { get; set; }

        [Display(Name = "")]
        public string ImagePath { get; set; }


        [Display(Name = "ProductId", ResourceType = typeof(Texts))]
        public int ProductId { get; set; }

        [Required(ErrorMessageResourceName = "ProductNameError", ErrorMessageResourceType = typeof(Texts))]
        [Display(Name = "ProductName", ResourceType = typeof(Texts))]
        public string Productnaam { get; set; }
        [Required(ErrorMessageResourceName = "ProductPriceError", ErrorMessageResourceType = typeof(Texts))]
        [Display(Name = "PriceItem", ResourceType = typeof(Texts))]
        public decimal Prijs { get; set; }
        [Required(ErrorMessageResourceName = "ProductDescriptionError", ErrorMessageResourceType = typeof(Texts))]
        [Display(Name = "ProductDescription", ResourceType = typeof(Texts))]
        public string Beschrijving { get; set; }
        [Display(Name = "CategoryName", ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "CategoryNameError", ErrorMessageResourceType = typeof(Texts))]
        public int CategorieId { get; set; }

        [Display(Name = "Alcohol", ResourceType = typeof(Texts))]
        public Nullable<double> AlcoholPercentage___ { get; set; }

        [Display(Name = "Content", ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "ProductContentError", ErrorMessageResourceType = typeof(Texts))]
        public double Inhoud_cl_ { get; set; }

        public int ProducentId { get; set; }

        [Display(Name = "SoldPer", ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "ProductSoldPerError", ErrorMessageResourceType = typeof(Texts))]
        public string VerkochtPer { get; set; }

        public ProductViewModel()
        {

        }

        public ProductViewModel(Product model)
        {
            ProductId = model.ProductId;
            Productnaam = model.Productnaam;
            Prijs = model.Prijs;
            Beschrijving = model.Beschrijving;
            CategorieId = model.CategorieId;
            AlcoholPercentage___ = model.AlcoholPercentage___;
            Inhoud_cl_ = model.Inhoud_cl_;
            ProducentId = model.ProducentId;
            VerkochtPer = model.VerkochtPer;

            

            Categorienaam = model.Category.Categorienaam;
            Producentnaam = model.Producer.ProducentNaam;

            //Ik blijf fouten krijgen bij veel op veel relatie, query resulteert naar 0. 

            using (DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities())
            {

                var query = db.Multimedias.Where(p => p.ProductId == ProductId);

                string absPath = query.First().ImagePath;
                string relPath = Path.GetFileName(absPath);
                ImagePath = "~/Afbeeldingen/" + relPath; 
                // var query = db.Multimedias.Where(c => c.p == categoryId).SelectMany(c => c.Articles)

                //db.Multimedias.Where(a => a.Products.Any(c => c.ProductId == ProductId)).ToList();  

                //if (query != null)
                //{
                //    ImagePath = query.FirstOrDefault().ImagePath;

                //}
                //else ImagePath = null;
            }


        }
    }
}