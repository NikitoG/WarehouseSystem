namespace WarehouseSystem.Services.Data.Contract
{
    using System.Collections.Generic;
    using System.Linq;
    using WarehouseSystem.Data.Models;

    public interface IMessageServices
    {
        Message Add(Message message);

        Message GetById(int id);

        int CountMessagesByReceiver(string userId);

        IQueryable<Message> GetReceivedMessage(string userId);

        IQueryable<Message> GetSentMessage(string userId);

        void AddCollection(IEnumerable<Message> allMessages);
    }
}
