namespace WarehouseSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int DivisionId { get; set; }

        public virtual Division Division { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}