using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp
{
    public partial class Category
    {
      
        public Category(CategoryViewModel model)
        {
            CategorieId = model.CategorieId;
            Categorienaam = model.Categorienaam;
            Beschrijving = model.Beschrijving; 
        }
    }

    public class CategoryViewModel
    {
        
         /*
          Een user moet geen category kunnen aanmaken, enkel maar de verschillende categoriën kunnen zien.
          Wanneer een user een categorie kiest, moet deze uiteraard de producten te zien krijgen.
          
          Een admin daarentegen moet een categorie kunnen aanmaken/aanpassen etc en een overzicht van alle categoriën zien.
         
          */
        public int CategorieId { get; set; }

        
        [Display(Name = "CategoryName" , ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "CategoryNameError", ErrorMessageResourceType = typeof(Texts))]
        public string Categorienaam { get; set; }

        [Required(ErrorMessageResourceName = "CategoryDescriptionError", ErrorMessageResourceType = typeof(Texts))]
        [Display(Name = "CategoryDescription", ResourceType = typeof(Texts))]
        public string Beschrijving { get; set; }

        public CategoryViewModel()
        {

        }

        public CategoryViewModel(Category model)
        {
            CategorieId = model.CategorieId;
            Categorienaam = model.Categorienaam;
            Beschrijving = model.Beschrijving; 
        }
    }
}