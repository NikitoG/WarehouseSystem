using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseSystem.Models
{
    public class Organization
    {
        private ICollection<User> employees;

        public Organization()
        {
            this.employees = new HashSet<User>();
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
    }
}
