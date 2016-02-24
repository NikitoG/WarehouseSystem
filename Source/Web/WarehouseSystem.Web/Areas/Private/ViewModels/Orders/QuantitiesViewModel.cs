namespace WarehouseSystem.Web.Areas.Private.ViewModels.Orders
{
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class QuantitiesViewModel : IMapFrom<OrderQuantity>, IHaveCustomMappings
    {
        public double Quantity { get; set; }

        public string Client { get; set; }

        public int Sku { get; set; }

        public string Product { get; set; }

        public double DeliveryUnit { get; set; }

        public double All => this.Quantity * this.DeliveryUnit;

        public int PurchaseOrderId { get; set; }

        public bool IsDone { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<OrderQuantity, QuantitiesViewModel>()
                .ForMember(x => x.Client, opt => opt.MapFrom(x => x.PurchaseOrder.Client.Name))
                .ForMember(x => x.Sku, opt => opt.MapFrom(x => x.Product.Sku))
                .ForMember(x => x.Product, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(x => x.DeliveryUnit, opt => opt.MapFrom(x => x.Product.DeliveryUnit))
                .ForMember(x => x.IsDone, opt => opt.MapFrom(x => x.PurchaseOrder.isDone));
        }
    }
}
