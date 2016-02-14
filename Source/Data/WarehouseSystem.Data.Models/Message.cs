using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message : BaseModel<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Content { get; set; }
        
        public DateTime DateOfCreate { get; set; }

        [Required]
        public string FromId { get; set; }

        [ForeignKey("FromId")]
        public virtual User From { get; set; }
        
        [Required]
        public string ToId { get; set; }

        [ForeignKey("ToId")]
        public  virtual User To { get; set; }
    }
}
