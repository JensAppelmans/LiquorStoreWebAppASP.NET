using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp
{
    public partial class Producer
    {
     

        public Producer(ProducerViewModel model)
        {
            ProducentId = model.ProducentId;
            ProducentNaam = model.ProducentNaam;
            Land = model.Land; 
        }
    }

    public class ProducerViewModel
    {
        /*Enkel de admin moet producer kunnen aanmaken of verwijderen.
          De user moet enkel kunnen kiezen op basis van producent 
         of producent te zien krijgen van een bepaald product */
        public int ProducentId { get; set; }

        [Required(ErrorMessageResourceName = "ProducerNameError", ErrorMessageResourceType = typeof(Texts))]
        [Display(Name = "ProducerName", ResourceType = typeof(Texts))]
        public string ProducentNaam { get; set; }

        [Required(ErrorMessageResourceName = "ProducerCountryError", ErrorMessageResourceType = typeof(Texts))]
        [Display(Name = "Country", ResourceType = typeof(Texts))]
        public string Land { get; set; }

        public ProducerViewModel()
        {

        }

        public ProducerViewModel(Producer model)
        {
            ProducentId = model.ProducentId;
            ProducentNaam = model.ProducentNaam;
            Land = model.Land; 
        }
    }
}