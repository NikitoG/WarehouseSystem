

using System.Security.Cryptography.X509Certificates;
using AutoMapper;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels
{
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string OrganizationName { get; set; }

        public int? ImageId { get; set; }

        public bool IsSuplier { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ForMember(x => x.OrganizationName, opt => opt.MapFrom(x => x.Organization.Name))
                .ForMember(x => x.IsSuplier, opt => opt.MapFrom(x => x.Organization.IsSupplier));
        }
    }
}