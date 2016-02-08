namespace WarehouseSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Organization
    {
        private ICollection<User> employees;
        private ICollection<PurchaseOrder> clients;
        private ICollection<PurchaseOrder> suppliers;
        private ICollection<ScheduleOrder> scheduleOrdersClient;
        private ICollection<ScheduleOrder> scheduleOrdersSupplier;

        public Organization()
        {
            this.employees = new HashSet<User>();
            this.clients = new HashSet<PurchaseOrder>();
            this.suppliers = new HashSet<PurchaseOrder>();
            this.scheduleOrdersClient = new HashSet<ScheduleOrder>();
            this.scheduleOrdersSupplier = new HashSet<ScheduleOrder>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        
        public string MateriallyResponsiblePerson { get; set; }

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

        public virtual ICollection<PurchaseOrder> Clients
        {
            get { return this.clients; }
            set { this.clients = value; }
        }

        public virtual ICollection<PurchaseOrder> Suppliers
        {
            get { return this.suppliers; }
            set { this.suppliers = value; }
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
    }
}
