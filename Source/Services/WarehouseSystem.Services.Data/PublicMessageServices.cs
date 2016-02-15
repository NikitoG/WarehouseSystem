using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.Data.Common;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Services.Data.Contract;

namespace WarehouseSystem.Services.Data
{
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
