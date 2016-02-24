namespace WarehouseSystem.Services.Data
{
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

    public class ImageServices : IImageServices
    {
        private IDbRepository<Image> images;

        public ImageServices(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public Image GetById(int id)
        {
            return this.images.GetById(id);
        }

        public Image Add(Image image)
        {
            this.images.Add(image);
            this.images.Save();

            return image;
        }
    }
}
