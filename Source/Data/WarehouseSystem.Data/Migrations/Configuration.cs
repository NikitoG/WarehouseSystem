using System;
using System.Net.Configuration;

namespace WarehouseSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using WarehouseSystem.Common;
    using WarehouseSystem.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<WarehouseSystemDbContext>
    {
        private PasswordHasher PasswordHasher = new PasswordHasher();
        private UserManager<User> userManager;
        private IRandomGenerator random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(WarehouseSystemDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedOrganization(context);
            this.SeedUsers(context);
        }

        private void SeedOrganization(WarehouseSystemDbContext context)
        {
            if (context.Organizations.Any())
            {
                return;
            }

            var organization = new Organization
            {
                Name = "WMS-NG",
                MateriallyResponsiblePerson = "Nikolay Georgiev",
                Address = "Sofia",
                Vat = "000000000",
                IsSupplier = false
            };

            context.Organizations.AddOrUpdate(x => x.Name, organization);
            context.SaveChanges();
        }

        private void SeedUsers(WarehouseSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            var role = new IdentityRole { Name = "Administrator" };
            roleManager.Create(role);

            var admin = new User
            {
                UserName = "admin@site.com",
                Email = "admin@site.com",
                PasswordHash = this.PasswordHasher.HashPassword("admin"),
                FirstName = "Nikolay",
                LastName = "Georgiev",
                CreatedOn = DateTime.Now
            };

            var organization = context.Organizations.FirstOrDefault();
            if (organization != null)
            {
                admin.OrganizationId = organization.Id;
            }

            userManager.Create(admin);
            userManager.AddToRole(admin.Id, "Administrator");

            context.SaveChanges();

            //for (int i = 0; i < 10; i++)
            //{
            //    var user = new User
            //    {
            //        Email = string.Format("{0}@{1}.com", this.random.RandomString(6, 16), this.random.RandomString(6, 16)),
            //        UserName = this.random.RandomString(6, 16)
            //    };

            //    this.userManager.Create(user, "123456");
            //}
        }
    }
}
