using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image : BaseModel<int>
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
