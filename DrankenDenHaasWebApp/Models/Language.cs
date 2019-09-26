using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrankenDenHaasWebApp
{
    public partial class Language
    {
        public static List<Language> Languages { get; set; }
        public static Dictionary<string, Language> LanguageDictionary { get; set; }

        public static void Initialize()
        {
            DrankencentraleDBJensAppelmansEntities db = new DrankencentraleDBJensAppelmansEntities();
            Languages = db.Languages.OrderBy(lan => lan.Taalnaam).ToList();
            LanguageDictionary = new Dictionary<string, Language>();
            foreach (Language l in Languages)
                LanguageDictionary[l.TaalId] = l;
        }
        public Language(LanguageViewModel model)
        {
            Taalnaam = model.Taalnaam;
            TaalId = model.TaalId;
        }
    }

    public class LanguageViewModel
    {
        /*User moet dit niet zien, moet enkel uit taaloptie kunnen kiezen 
         Admin daarentegen moet wel talen kunnen toevoegen en verwijderen
         
         Optie talen eventueel voor later!
             
             */

        [Required]
        public string Taalnaam { get; set; }

        [Required]
        [Display(Name = "Geef afkorting van de taal vb nl of en")]
        public string TaalId { get; set; } 

        public LanguageViewModel()
        {

        }

        public LanguageViewModel(Language model)
        {
            Taalnaam = model.Taalnaam;
            TaalId = model.TaalId; 
        }
    }
}
