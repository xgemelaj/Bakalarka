using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ASP.NET_MVC_MajsterStrelby.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public Player ActualPlayerInformation { get; set; }
    }

    public class SkillTreeViewModel
    {
        public Player ActualPlayerInformation { get; set; }
        public int PossibleUpgrades { get; set; }
    }

    public class AchievmentsViewModel
    {
        public Player ActualPlayerInformation { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Položka {0} musí byť aspoň {2} znakov dlhá.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nové heslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdenie nového hesla")]
        [Compare("NewPassword", ErrorMessage = "Heslá sa nezhodujú.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Aktuálne heslo")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Položka {0} musí byť aspoň {2} znakov dlhá.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nové heslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdenie nového hesla")]
        [Compare("NewPassword", ErrorMessage = "Heslá sa nezhodujú.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Telefónne číslo")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Kód")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefónne číslo")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}