using System.Linq;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int Sku { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Barcode { get; set; }

        public double DeliveryUnit { get; set; }

        public string Category { get; set; }

        public int? ImageId { get; set; }

        public double Quantities { get; set; }

        public int SupplierId { get; set; }

        public string Supplier { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Supplier, opt => opt.MapFrom(x => x.Supplier.Name))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.Quantities, opt => opt.MapFrom(x => 0d));
        }
    }
}