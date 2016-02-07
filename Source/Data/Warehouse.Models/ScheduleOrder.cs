namespace WarehouseSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ScheduleOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DayOfWeek OrderDay { get; set; }
        
        [Required]
        public DayOfWeek DelivaryDay { get; set; }

        [Required]
        public int ClientId { get; set; }

        public virtual Organization Client { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public virtual Organization Supplier { get; set; }
    }
}
