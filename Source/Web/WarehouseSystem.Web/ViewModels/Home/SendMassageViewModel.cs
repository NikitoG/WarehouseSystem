using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc.Html;

namespace WarehouseSystem.Web.ViewModels.Home
{
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class SendMassageViewModel : IMapFrom<PublicMessage>
    {
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Content { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}