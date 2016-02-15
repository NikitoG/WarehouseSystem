namespace WarehouseSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using WarehouseSystem.Data.Common.Models;

    public class PublicMessage : BaseModel<int>
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
