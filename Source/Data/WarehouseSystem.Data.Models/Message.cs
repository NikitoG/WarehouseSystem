namespace WarehouseSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WarehouseSystem.Data.Common.Models;


    public class Message : BaseModel<int>
    {
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Content { get; set; }

        [Required]
        public string FromId { get; set; }

        [ForeignKey("FromId")]
        public virtual User From { get; set; }

        [Required]
        public string ToId { get; set; }

        [ForeignKey("ToId")]
        public virtual User To { get; set; }
    }
}
