using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrankenDenHaasWebApp
{
    public partial class Payment
    {
        static List<Payment> betalingen = new List<Payment>();
        public Payment()
        {

        }

        public Payment(PaymentViewModel model)
        {
            BetalingsId = model.BetalingsId;
            DatumVanBetaling = model.DatumVanBetaling;
            BedragBetaald = model.BedragBetaald;
            BetaalKaartId = model.BetaalKaartId;
            BestelId = model.BestelId; 
        }
    }

    public class PaymentViewModel
    {
        /* Admin dient een overzicht te krijgen van alle betalingen, maar dient normaal ook niks te moeten aanpassen
           Een user dient enkel te zien dat zijn betaling succesvol verlopen is, waarna afgerekend in orderViewModel op true wordt gezet.
         
         */

        [Display(Name = "Id van betaling")]
        public int BetalingsId { get; set; }

        [Display(Name = "Datum van betaling")]
        public System.DateTime DatumVanBetaling { get; set; }

        [Display(Name = "Bedrag betaald")]
        public decimal BedragBetaald { get; set; }

        [Display(Name = "ID van betaalkaart")]
        public int BetaalKaartId { get; set; }

        [Display(Name = "Id van bestelling")]
        public int BestelId { get; set; }

        public string Kaartnummer { get; set; }

        public PaymentViewModel()
        {

        }

        public PaymentViewModel(Payment model)
        {
            BetalingsId = model.BetalingsId;
            DatumVanBetaling = model.DatumVanBetaling;
            BedragBetaald = model.BedragBetaald;
            BetaalKaartId = model.BetaalKaartId;
            BestelId = model.BestelId;
            Kaartnummer = model.Debitcard.Kaartnummer; 
            
        }
    }
}