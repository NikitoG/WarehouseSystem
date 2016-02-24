namespace WarehouseSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using WarehouseSystem.Data.Common.Models;

    public class ScheduleOrder : BaseModel<int>
    {
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
