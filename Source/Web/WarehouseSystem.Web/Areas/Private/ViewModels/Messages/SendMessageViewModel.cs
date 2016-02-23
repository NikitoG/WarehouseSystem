using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using WarehouseSystem.Web.Infrastructure.Mapping;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Messages
{
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