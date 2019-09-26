using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web; 
using DrankenDenHaasWebApp.Translations; 

namespace DrankenDenHaasWebApp
{
    public partial class Customer
    {


        public Customer(CustomerViewModel model)
        {
            KlantId = model.KlantId;
            UserId = model.UserId;
        }
    }

    public class CustomerViewModel
    {
        /* 
         Een user moet dit model niet te zien krijgen, dit dient enkel voor de admin.
         Een admin krijgt hier te zien welke users feitelijk klant zijn.
         
         Even vermelden dat een user pas een klant komt wanneer deze effectief iets gekocht heeft.
         Dus na een aankoop van een product dient deze user gelinkt te worden aan KlantTabel met UserId.
         
         ViewModel kan nog uitgebreid worden later
         
         */

        //public string Voornaam { get; set; }
        //public string Achternaam { get; set; }
        [Display(Name = "BussinessAccount", ResourceType = typeof(Texts))]
        public bool ?Iszakelijk { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Texts))]
        public string Usernaam { get; set; }

        [Display(Name = "CustomerId", ResourceType = typeof(Texts))]
        public int KlantId { get; set; }

        [Display(Name = "UserId", ResourceType = typeof(Texts))]
        public string UserId { get; set; }

        //[Display(Name = "Is klant sinds?")]
        //public DateTime KlantSinds { get; set; }

        public CustomerViewModel()
        {

        }

        public CustomerViewModel(Customer model)
        {
            KlantId = model.KlantId;
            UserId = model.UserId;
            Usernaam = model.AspNetUser.UserName;
            Iszakelijk = model.AspNetUser.IsZakelijk; 
            //Voornaam = model.AspNetUser.Voornaam;
            //Achternaam = model.AspNetUser.Achternaam; 
        }
    }

   public class CustomerDetailViewModel
    {

        [Display(Name = "PersonFirstname", ResourceType = typeof(Texts))]
        public string Voornaam { get; set; }
        [Display(Name = "PersonSurname", ResourceType = typeof(Texts))]
        public string Achternaam { get; set; }
        [Display(Name = "BussinessAccount", ResourceType = typeof(Texts))]
        public bool? Iszakelijk { get; set; }
        [Display(Name = "UserName", ResourceType = typeof(Texts))]
        public string Usernaam { get; set; }
        [Display(Name = "CustomerId", ResourceType = typeof(Texts))]
        public int KlantId { get; set; }
        [Display(Name = "UserId", ResourceType = typeof(Texts))]
        public string UserId { get; set; }
        [Display(Name = "PersonLanguage", ResourceType = typeof(Texts))]
        public string Taal { get; set; }
        [Display(Name = "PersonEmail", ResourceType = typeof(Texts))]
        public string Email { get; set; }
        [Display(Name = "PersonPhone", ResourceType = typeof(Texts))]
        public string  Telefoon { get; set; }

        public CustomerDetailViewModel()
        {

        }

        public CustomerDetailViewModel(Customer model)
        {
            KlantId = model.KlantId;
            UserId = model.UserId;
            Usernaam = model.AspNetUser.UserName;
            Iszakelijk = model.AspNetUser.IsZakelijk;
            Voornaam = model.AspNetUser.Voornaam;
            Achternaam = model.AspNetUser.Achternaam;
            Email = model.AspNetUser.Email;
            Taal = model.AspNetUser.Language.Taalnaam ;
            Telefoon = model.AspNetUser.Telefoon;
        }
    }
}