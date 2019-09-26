using DrankenDenHaasWebApp.Translations; 
using System.ComponentModel.DataAnnotations;


namespace DrankenDenHaasWebApp.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Display(Name = "Username", ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "UsernameError", ErrorMessageResourceType = typeof(Texts))]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Display(Name = "OldPassword", ResourceType = typeof(Texts))]
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Texts))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "PasswordConfirm")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "Username", ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "UsernameError", ErrorMessageResourceType = typeof(Texts))]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceName = "PasswordError", ErrorMessageResourceType = typeof(Texts))]
        [Display(Name = "Password", ResourceType = typeof(Texts))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Texts))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Display(Name = "Username", ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "UsernameError", ErrorMessageResourceType = typeof(Texts))]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Texts))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Texts))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessageResourceName = "EmailError", ErrorMessageResourceType = typeof(Texts))]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "PersonLanguage", ResourceType = typeof(Texts))]
        [Required(ErrorMessageResourceName = "LanguageError", ErrorMessageResourceType = typeof(Texts))]
        public string taalId { get; set; }

        [Display(Name = "BussinessAccount", ResourceType = typeof(Texts))]
        public bool IsZakelijk { get; set; }

      
    }

    public class AccountDetailViewModel
    {
        public static bool justRegistered = false;

        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        public int AdresId { get; set; }

        public string Usernaam { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsZakelijk { get; set; }

       
        public string Voornaam { get; set; }

        
        public string Achternaam { get; set; }

        [Required]
        public string Telefoon { get; set; }

        
        public string BTW_nummer { get; set; }

        [Required]
        [Display(Name = "PersonLanguage", ResourceType = typeof(Texts))]
        public string TaalId { get; set; }

        [Required]
        public string Land { get; set; }

        [Required]
        public string Provincie { get; set; }

        [Required]
        public string Stad { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Straatnaam { get; set; }

        [Required]
        [Display(Name = "Nummer of bus")]
        public string Nummer_Bus { get; set; }

        public AccountDetailViewModel(ApplicationUser user, Adress addres)
        {
            PasswordHash = user.PasswordHash;
            SecurityStamp = user.SecurityStamp; 
            UserId = user.Id;
            Voornaam = user.Voornaam;
            Achternaam = user.Achternaam;
            Email = user.Email;
            Telefoon = user.Telefoon;
            Usernaam = user.UserName;
            TaalId = user.TaalId;
            IsZakelijk = user.IsZakelijk;
            BTW_nummer = user.BTW_nummer;
            AdresId = addres.AdresId;
            Land = addres.Land;
            Provincie = addres.Provincie;
            Stad = addres.Stad;
            Straatnaam = addres.Straatnaam;
            Postcode = addres.Postcode;
            Nummer_Bus = addres.Nummer_Bus;
        }

        public AccountDetailViewModel(ApplicationUser user) 
        {

            UserId = user.Id;
            Voornaam = user.Voornaam;
            Achternaam = user.Achternaam;
            Email = user.Email;
            Telefoon = user.Telefoon;
            Usernaam = user.UserName;
            TaalId = user.TaalId;
            IsZakelijk = user.IsZakelijk;
            BTW_nummer = user.BTW_nummer;
            PasswordHash = user.PasswordHash;
            SecurityStamp = user.SecurityStamp;
        }

        public AccountDetailViewModel()
        {

        }
    }
}
