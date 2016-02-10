using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.Services.Data.Contract
{
    public interface IProductServices
    {
        IList<string> GetNames();
    }
}
