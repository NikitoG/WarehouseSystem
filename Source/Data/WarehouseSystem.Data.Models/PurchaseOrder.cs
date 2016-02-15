using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PurchaseOrder : BaseModel<int>
    {
        private ICollection<OrderQuantity> orderQuantities;

        public PurchaseOrder()
        {
            this.orderQuantities = new HashSet<OrderQuantity>();
        }

        [Required]
        public DateTime DateOfOrder { get; set; }

        [Required]
        public DateTime DateOfDelivery { get; set; }

        [Required]
        public int ClientId { get; set; }
        
        public virtual Organization Client { get; set; }

        [Required]
        public int SupplierId { get; set; }
        
        public virtual Organization Supplier { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<OrderQuantity> OrderQuantities
        {
            get { return this.orderQuantities; }
            set { this.orderQuantities = value; }
        } 
    }
}
