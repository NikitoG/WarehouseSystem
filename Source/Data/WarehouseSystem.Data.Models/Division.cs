using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Division : BaseModel<int>
    {
        private ICollection<Category> categories;

        public Division()
        {
            this.categories = new HashSet<Category>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        } 
    }
}
