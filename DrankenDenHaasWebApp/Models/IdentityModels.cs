using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace DrankenDenHaasWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string Email { get; set; }

        public bool IsZakelijk { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Telefoon { get; set; }

        public string BTW_nummer { get; set; }

        public string TaalId { get; set; }

        public DateTime? GeboorteDatum { get; set; }

        public ApplicationUser()
        {
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

       
    }
}