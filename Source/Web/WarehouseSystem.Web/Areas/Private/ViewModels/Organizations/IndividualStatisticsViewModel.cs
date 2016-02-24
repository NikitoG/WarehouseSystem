namespace WarehouseSystem.Web.Areas.Private.ViewModels.Organizations
{
    using System.Linq;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class IndividualStatisticsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public int Partners { get; set; }

        public int Messages { get; set; }

        public int Orders { get; set; }

        public int Products { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, IndividualStatisticsViewModel>()
                .ForMember(x => x.Partners, opt => opt.MapFrom(x => x.Organization.Partners.Count))
                .ForMember(x => x.Messages, opt => opt.MapFrom(x => x.ReceivedMessages.Count(m => m.IsRead == false)))
                .ForMember(x => x.Orders, opt => opt.MapFrom(x => x.Organization.IsSupplier ? x.Organization.SupplierOrders.Count(o => o.isDone == false) : x.Organization.ClientOrders.Count))
                .ForMember(x => x.Products, opt => opt.MapFrom(x => x.Organization.Products.Any() ? x.Organization.Products.Count : x.Organization.Partners.Sum(p => p.Products.Count)));
        }
    }
}
