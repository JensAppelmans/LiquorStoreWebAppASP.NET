using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrankenDenHaasWebApp
{
    public partial class Multimedia
    {
        public Multimedia()
        {

        }

        public Multimedia(MultimediaViewModel model)
        {
            MultimediaId = model.MultimediaId;
            ImagePath = model.ImagePath; 
        }
    }

    public class MultimediaViewModel
    {
        /* Hier moet de admin foto's, video's etc kunnen uploaden naar de browser 
         User moet dit niet zien*/
        
        
        public int MultimediaId { get; set; }

        [Display(Name = "Choose Picture")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public int? ProductId { get; set; }

        public MultimediaViewModel()
        {

        }

        public MultimediaViewModel(Multimedia model)
        {
            MultimediaId = model.MultimediaId;
            ImagePath = model.ImagePath;
            ProductId = model.ProductId; 
        }
    }
}