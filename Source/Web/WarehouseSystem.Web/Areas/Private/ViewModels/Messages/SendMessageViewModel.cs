namespace WarehouseSystem.Web.Areas.Private.ViewModels.Messages
{
    using System.ComponentModel.DataAnnotations;

    public class SendMessageViewModel
    {
        [Required]
        public string To { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
