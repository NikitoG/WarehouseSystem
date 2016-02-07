using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Warehouse.Models;

namespace Warehouse.Data
{
    public class WarehouseSystemDbContext : IdentityDbContext<User>, IWarehouseSystemDbContext
    {
        public WarehouseSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static WarehouseSystemDbContext Create()
        {
            return new WarehouseSystemDbContext();
        }
    }
}
