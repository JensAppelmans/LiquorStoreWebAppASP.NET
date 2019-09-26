using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrankenDenHaasWebApp
{
    public partial class Debitcard
    {
       
        public Debitcard(DebitcardViewModel model)
        {
            BetaalkaartId = model.BetaalkaartId;
            Id = model.Id;
            KaartNaam = model.KaartNaam;
            Kaartnummer = model.Kaartnummer;
            DatumGeldigTot = model.DatumGeldigTot;
            Primairekaart = model.Primairekaart; 
        }
    }

    public class DebitcardViewModel
    {
        /* 
         Een user moet zijn betaalkaart kunnen toevoegen en kiezen (als er meerdere zijn) met welke hij/zij wilt betalen
         
         Een admin moet een overzicht krijgen van de betaalkaarten van de verschillende users, 
         maar moet zelf geen kaarten kunnen toevoegen. Eventueel wel admin kaarten laten verwijderen. 
         
         */

        public int BetaalkaartId { get; set; }
        //alleen zichtbaar voor admin, hidden voor user aangezien zijn UserId hier automatisch zal ingevuld worden wanneer 
        //deze een kaart wil toevoegen.
        public string Id { get; set; } 

        [Required]
        [Display (Name="Naam op de kaart")]
        public string KaartNaam { get; set; }

        [Required]
        [Display( Name = "IBAN kaartnummer")]
        public string Kaartnummer { get; set; }

        [Required]
        [Display(Name = "Kaart is geldig tot")]
        public System.DateTime DatumGeldigTot { get; set; }

        //[Display(Name = "")]
        public Nullable<bool> Primairekaart { get; set; }

        public DebitcardViewModel()
        {
                
        }

        public DebitcardViewModel(Debitcard model)
        {
            BetaalkaartId = model.BetaalkaartId;
            Id = model.Id;
            KaartNaam = model.KaartNaam;
            Kaartnummer = model.Kaartnummer;
            DatumGeldigTot = model.DatumGeldigTot;
            Primairekaart = model.Primairekaart; 
        }
    }

}