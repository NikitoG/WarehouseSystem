namespace WarehouseSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private ICollection<OrderQuantity> orderQuantities;

        public Product()
        {
            this.orderQuantities = new HashSet<OrderQuantity>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Sku { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Barcode { get; set; }

        public double HeigthInCm { get; set; }

        public double WidthInCm { get; set; }

        public int WeightInGr { get; set; }

        public double DeliveryUnit { get; set; }

        public double Stock { get; set; }

        public int MinDayOfExpiryInDays { get; set; }

        public bool IsBlocked { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<OrderQuantity> OrderQuantities
        {
            get { return this.orderQuantities; }
            set { this.orderQuantities = value; }
        } 
    }
}
