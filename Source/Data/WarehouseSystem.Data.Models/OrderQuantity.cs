using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderQuantity : BaseModel<int>
    {
        [Required]
        public double Quantity { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}