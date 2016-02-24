namespace WarehouseSystem.Web.Areas.Private.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class SupplierViewModel : IMapFrom<Organization>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public string MateriallyResponsiblePerson { get; set; }

        public string LogoUrl { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string Vat { get; set; }

        public string Address { get; set; }

        public int SupplierOrders { get; set; }

        public int Products { get; set; }

        public int Partners { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Organization, SupplierViewModel>()
                .ForMember(m => m.SupplierOrders, opt => opt.MapFrom(t => t.SupplierOrders.Count))
                .ForMember(m => m.Products, opt => opt.MapFrom(t => t.Products.Count))
                .ForMember(m => m.Partners, opt => opt.MapFrom(t => t.Partners.Count));
        }
    }
}
