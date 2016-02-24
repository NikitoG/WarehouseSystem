namespace WarehouseSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WarehouseSystem.Data.Common.Models;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<PurchaseOrder> orders;
        private ICollection<Message> sendMessages;
        private ICollection<Message> receivedMessages;

        public User()
        {
            this.orders = new HashSet<PurchaseOrder>();
            this.sendMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
        }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Position { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<PurchaseOrder> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }

        public virtual ICollection<Message> SendMessages
        {
            get { return this.sendMessages; }
            set { this.sendMessages = value; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}