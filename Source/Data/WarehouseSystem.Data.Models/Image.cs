using WarehouseSystem.Data.Common.Models;

namespace WarehouseSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image : BaseModel<int>
    {
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
