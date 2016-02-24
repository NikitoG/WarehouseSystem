namespace WarehouseSystem.Data.Models
{
    using WarehouseSystem.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
