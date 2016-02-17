using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Services.Data.Contract
{
    public interface IImageServices
    {
        Image GetById(int id);
    }
}
