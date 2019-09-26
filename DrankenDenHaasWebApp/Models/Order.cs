using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp
{
    public partial class Order
    {
       

        public Order(OrderViewModel model)
        {
            BestelId = model.BestelId;
            Id = model.Id;
            DatumVanBestelling = model.DatumVanBestelling;
            Totaalprijs = model.Totaalprijs;
            IsBetaald = model.IsBetaald;
        }
    }


    public class OrderViewModel
    {
        /* 
         Nadat een user iets heeft gekocht wordt het een klant en kan het zijn eerdere bestellingen bekijken.
         Enkel bekijken en kan niets aanpassen.
         
         Ook een admin moet per klant alle bestellingen kunnen bekijken, maar dient ook niks te kunnen aanpassen.
         
         */

        [Display(Name = "OrderId", ResourceType = typeof(Texts))]
        public int BestelId { get; set; }

        [Display(Name = "CustomerId", ResourceType = typeof(Texts))] //eventueel enkel zichtbaar voor admin
        public int Id { get; set; }

        [Display(Name = "OrderWhen", ResourceType = typeof(Texts))]
        public Nullable<System.DateTime> DatumVanBestelling { get; set; }

        [Display(Name = "TotalPrice", ResourceType = typeof(Texts))]
        public decimal Totaalprijs { get; set; }

        [Display(Name = "IsPayed", ResourceType = typeof(Texts))]
        public Nullable<bool> IsBetaald { get; set; }


        [Display(Name = "Username", ResourceType = typeof(Texts))]
        public string  Username { get; set; }

        public OrderViewModel()
        {

        }

        public OrderViewModel(Order model)
        {
            BestelId = model.BestelId;
            Id = model.Id;
            DatumVanBestelling = model.DatumVanBestelling;
            Totaalprijs = model.Totaalprijs;
            IsBetaald = model.IsBetaald;
            Username = model.Customer.AspNetUser.UserName; 

        }
    }
}