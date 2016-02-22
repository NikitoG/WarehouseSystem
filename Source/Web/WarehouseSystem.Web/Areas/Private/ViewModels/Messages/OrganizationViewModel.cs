﻿using WarehouseSystem.Data.Models;
using WarehouseSystem.Web.Infrastructure.Mapping;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Messages
{
    public class OrganizationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}