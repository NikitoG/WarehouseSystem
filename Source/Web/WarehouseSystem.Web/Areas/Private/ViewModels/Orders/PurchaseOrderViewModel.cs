namespace WarehouseSystem.Web.Areas.Private.ViewModels.Orders
{
    using System;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class PurchaseOrderViewModel : IMapFrom<PurchaseOrder>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public string ClientName { get; set; }

        public string Creator { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PurchaseOrder, PurchaseOrderViewModel>()
                .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client.Name))
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Creator.Email));
        }
    }
}
