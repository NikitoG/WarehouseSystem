namespace WarehouseSystem.Web.Areas.Private.ViewModels.Messages
{
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class OrganizationViewModel : IMapFrom<Data.Models.Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
