using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Messages
{
    public class SendMessageViewModel
    {
        public IEnumerable<UserViewModel> Recievers { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 2)]
        public string Content { get; set; }
    }
}