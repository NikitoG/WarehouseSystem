namespace WarehouseSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WarehouseSystem.Data.Common.Models;

    public class Product : BaseModel<int>
    {
        private ICollection<OrderQuantity> orderQuantities;

        public Product()
        {
            this.orderQuantities = new HashSet<OrderQuantity>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int Sku { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Barcode { get; set; }

        public double HeigthInCm { get; set; }

        public double WidthInCm { get; set; }

        public int WeightInGr { get; set; }

        public double DeliveryUnit { get; set; }

        public double Stock { get; set; }

        public int MinDayOfExpiryInDays { get; set; }

        public bool IsBlocked { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int SupplierId { get; set; }

        public virtual Organization Supplier { get; set; }

        public virtual ICollection<OrderQuantity> OrderQuantities
        {
            get { return this.orderQuantities; }
            set { this.orderQuantities = value; }
        }
    }
}
