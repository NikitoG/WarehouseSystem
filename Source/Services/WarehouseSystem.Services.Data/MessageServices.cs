namespace WarehouseSystem.Services.Data
{
    using System.Linq;
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

    public class MessageServices : IMessageServices
    {
        private IDbRepository<Message> messages;

        public MessageServices(IDbRepository<Message> messages)
        {
            this.messages = messages;
        }

        public Message Add(Message message)
        {
            this.messages.Add(message);
            this.messages.Save();

            return message;
        }

        public Message GetById(int id)
        {
            var message = this.messages.GetById(id);
            return message;
        }

        public int CountMessagesByReceiver(string userId)
        {
            return this.messages.All().Count(m => m.ToId == userId && m.ModifiedOn == null);
        }

        public IQueryable<Message> GetReceivedMessage(string userId)
        {
            return this.messages.All()
                .Where(m => m.ToId == userId)
                .OrderByDescending(m => m.CreatedOn)
                .ThenBy(m => m.Id);
        }

        public IQueryable<Message> GetSentMessage(string userId)
        {
            return this.messages.All()
                .Where(m => m.FromId == userId)
                .OrderByDescending(m => m.CreatedOn)
                .ThenBy(m => m.Id);
        }
    }
}
