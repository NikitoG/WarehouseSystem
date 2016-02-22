using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.UI.WebControls;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Web.Infrastructure.Mapping;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Profile
{
    public class ProfileViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

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

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}