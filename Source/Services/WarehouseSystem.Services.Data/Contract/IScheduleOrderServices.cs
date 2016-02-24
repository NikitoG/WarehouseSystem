namespace WarehouseSystem.Services.Data.Contract
{
    public interface IScheduleOrderServices
    {
        int GetNextDayOfOrder(int clientId, int supplierId);
    }
}
