﻿namespace WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class PartnersViewModel : IMapFrom<Data.Models.Organization>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Organization, PartnersViewModel>()
                .ForMember(x => x.Categories, opt => opt.MapFrom(x => x.Products.GroupBy(p => p.Category.Name).Select(p => p.Key)));
        }
    }
}
