using System;
using System.Linq;
using WarehouseSystem.Data.Common;
using WarehouseSystem.Data.Models;

namespace WarehouseSystem.Services.Data
{
    using WarehouseSystem.Services.Data.Contract;

    public class ScheduleOrderServices : IScheduleOrderServices
    {
        private IDbRepository<ScheduleOrder> scheduleOrders;

        public ScheduleOrderServices(IDbRepository<ScheduleOrder> scheduleOrders)
        {
            this.scheduleOrders = scheduleOrders;
        }

        public int GetNextDayOfOrder(int clientId, int supplierId)
        {
            var days = this.scheduleOrders.All()
                .Where(x => x.ClientId == clientId && x.SupplierId == supplierId)
                .OrderBy(x => x.OrderDay)
                .Select(x => (int)x.OrderDay)
                .ToList();
            var today = (int)DateTime.Now.DayOfWeek;
            for (int i = today; i < today + 7; i++)
            {
                if (days.Contains(i % 7))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
