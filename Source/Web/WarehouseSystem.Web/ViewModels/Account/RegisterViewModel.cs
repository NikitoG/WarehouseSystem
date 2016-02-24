namespace WarehouseSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class RegisterViewModel : IMapFrom<User>
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Position")]
        [StringLength(20, MinimumLength = 2)]
        public string Position { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}
