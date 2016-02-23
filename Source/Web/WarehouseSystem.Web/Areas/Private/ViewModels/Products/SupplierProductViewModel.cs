using System.ComponentModel.DataAnnotations;
using AutoMapper;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels;
using WarehouseSystem.Web.Infrastructure.Mapping;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Products
{
    public class SupplierProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int Sku { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Barcode { get; set; }

        public double HeigthInCm { get; set; }

        public double WidthInCm { get; set; }

        public int WeightInGr { get; set; }

        public double DeliveryUnit { get; set; }

        public int MinDayOfExpiryInDays { get; set; }

        public bool IsBlocked { get; set; }

        public CategoryViewModel Category { get; set; }

        public int? ImageId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, SupplierProductViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => new CategoryViewModel { Id = x.CategoryId, Name = x.Category.Name }))
                .ReverseMap();
        }
    }
}