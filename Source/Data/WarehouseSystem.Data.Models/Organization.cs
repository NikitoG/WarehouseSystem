using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Organization : BaseModel<int>
    {
        private ICollection<User> employees;
        private ICollection<PurchaseOrder> clientOrders;
        private ICollection<PurchaseOrder> supplierOrders;
        private ICollection<ScheduleOrder> scheduleOrdersClient;
        private ICollection<ScheduleOrder> scheduleOrdersSupplier;
        private ICollection<Product> products;
        private ICollection<Organization> partners;

        public Organization()
        {
            this.employees = new HashSet<User>();
            this.clientOrders = new HashSet<PurchaseOrder>();
            this.supplierOrders = new HashSet<PurchaseOrder>();
            this.scheduleOrdersClient = new HashSet<ScheduleOrder>();
            this.scheduleOrdersSupplier = new HashSet<ScheduleOrder>();
            this.products = new HashSet<Product>();
            this.partners = new HashSet<Organization>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public string MateriallyResponsiblePerson { get; set; }

        public string LogoUrl { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string Vat { get; set; }

        public string Address { get; set; }

        public bool IsSupplier { get; set; }

        public virtual ICollection<User> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        public virtual ICollection<PurchaseOrder> ClientOrders
        {
            get { return this.clientOrders; }
            set { this.clientOrders = value; }
        }

        public virtual ICollection<PurchaseOrder> SupplierOrders
        {
            get { return this.supplierOrders; }
            set { this.supplierOrders = value; }
        }

        public virtual ICollection<ScheduleOrder> ScheduleOrdersClient
        {
            get { return this.scheduleOrdersClient; }
            set { this.scheduleOrdersClient = value; }
        }

        public virtual ICollection<ScheduleOrder> ScheduleOrdersSupplier
        {
            get { return this.scheduleOrdersSupplier; }
            set { this.scheduleOrdersSupplier = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public virtual ICollection<Organization> Partners
        {
            get { return this.partners; }
            set { this.partners = value; }
        }
    }
}
