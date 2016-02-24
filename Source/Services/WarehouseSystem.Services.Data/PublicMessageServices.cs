namespace WarehouseSystem.Services.Data
{
    using WarehouseSystem.Data.Common;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;

    public class PublicMessageServices : IPublicMessageServices
    {
        private IDbRepository<PublicMessage> publicMessages;

        public PublicMessageServices(IDbRepository<PublicMessage> publicMessages)
        {
            this.publicMessages = publicMessages;
        }

        public PublicMessage Add(PublicMessage message)
        {
            this.publicMessages.Add(message);
            this.publicMessages.Save();

            return message;
        }
    }
}
