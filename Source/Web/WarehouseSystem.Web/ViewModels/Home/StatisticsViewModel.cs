using AutoMapper;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Web.Infrastructure.Mapping;

namespace WarehouseSystem.Web.ViewModels.Home
{
    public class StatisticsViewModel : IMapFrom<Organization>, IHaveCustomMappings
    {
        public bool IsSupplier { get; set; }

        public int Products { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Organization, StatisticsViewModel>()
                .ForMember(m => m.IsSupplier, opt => opt.MapFrom(t => t.IsSupplier))
                .ForMember(m => m.Products, opt => opt.MapFrom(t => t.Products.Count))
                .ReverseMap();
        }
    }
}