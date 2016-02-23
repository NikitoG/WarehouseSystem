using System;

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
            this.SeedDivisions(context);
            this.SeedCategories(context);
            this.SeedProducts(context);
            this.SeedMessages(context);
            this.SeedScheduleOrder(context);
            this.SeedPartners(context);
        }

        private void SeedPartners(WarehouseSystemDbContext context)
        {
            var suppliers = context.Organizations.Where(x => x.IsSupplier == true).ToList();
            var customers = context.Organizations.Where(x => x.IsSupplier == false).ToList();
            foreach (var currentCustomer in customers)
            {
                if (currentCustomer.Partners.Any())
                {
                    continue;
                }

                for (int j = 0; j < this.random.RandomNumber(0, suppliers.Count - 1); j++)
                {
                    var currnetSupplier = suppliers[this.random.RandomNumber(0, suppliers.Count - 1)];
                    if (!currentCustomer.Partners.Contains(currnetSupplier))
                    {
                        currentCustomer.Partners.Add(currnetSupplier);
                        currnetSupplier.Partners.Add(currentCustomer);
                    }
                }
            }

            context.SaveChanges();
        }

        private void SeedScheduleOrder(WarehouseSystemDbContext context)
        {
            if (context.Organizations.Any())
            {
                return;
            }

            var suppliers = context.Organizations.Where(x => x.IsSupplier == true).ToList();
            var customers = context.Organizations.Where(x => x.IsSupplier == false).ToList();
            for (int i = 0; i < suppliers.Count; i++)
            {
                for (int j = 0; j < this.random.RandomNumber(0, customers.Count - 1); j++)
                {
                    var newScheduleOrder = new ScheduleOrder()
                    {
                        OrderDay = (DayOfWeek)this.random.RandomNumber(0, 6),
                        DelivaryDay = (DayOfWeek)this.random.RandomNumber(0, 6),
                        Supplier = suppliers[this.random.RandomNumber(0, suppliers.Count - 1)],
                        Client = customers[(i + j) % customers.Count],

                    };

                    context.ScheduleOrders.Add(newScheduleOrder);
                }
            }

            context.SaveChanges();
        }

        private void SeedMessages(WarehouseSystemDbContext context)
        {
            if (context.Messages.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            for (int i = 0; i < 50; i++)
            {
                var newMessage = new Message()
                {
                    Title = $"Title {i}",
                    Content = $"Content {i}",
                    FromId = users[this.random.RandomNumber(0, users.Count - 1)].Id,
                    From = users[this.random.RandomNumber(0, users.Count - 1)],
                    ToId = users[this.random.RandomNumber(0, users.Count - 1)].Id,
                    To = users[this.random.RandomNumber(0, users.Count - 1)]
                };

                context.Messages.Add(newMessage);
            }

            context.SaveChanges();
        }

        private void SeedProducts(WarehouseSystemDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            var categories = context.Categories.ToList();
            var suppliers = context.Organizations.Where(x => x.IsSupplier == true).ToList();
            for (int i = 0; i < categories.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var newProduct = new Product()
                    {
                        Name = $"Product - {i}{j}",
                        Barcode = this.random.RandomNumber(1000, 999999999).ToString(),
                        Category = categories[i],
                        DeliveryUnit = this.random.RandomNumber(4, 16),
                        Sku = categories[i].Id + ((i + 1) * j),
                        Supplier = suppliers[this.random.RandomNumber(0, suppliers.Count - 1)]
                    };

                    context.Products.Add(newProduct);
                }
            }

            context.SaveChanges();
        }

        private void SeedCategories(WarehouseSystemDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var divisions = context.Divisions.ToList();
            for (int i = 0; i < divisions.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var newCategory = new Category()
                    {
                        Name = $"Category - {i}{j}",
                        Division = divisions[i]
                    };

                    context.Categories.Add(newCategory);
                }
            }

            context.SaveChanges();
        }

        private void SeedDivisions(WarehouseSystemDbContext context)
        {
            if (context.Divisions.Any())
            {
                return;
            }

            var division = new[] { "Dairy", "Meat", "Sweet", "Food" };
            for (int i = 0; i < division.Length; i++)
            {
                var newDivision = new Division()
                {
                    Name = division[i]
                };

                context.Divisions.Add(newDivision);
            }

            context.SaveChanges();
        }

        private void SeedOrganization(WarehouseSystemDbContext context)
        {
            if (context.Organizations.Any())
            {
                return;
            }

            var organization = new Organization()
            {
                Name = "VW-NG",
                MateriallyResponsiblePerson = "Nikolay Georgiev",
                Address = "Sofia",
                Vat = "000000000",
                IsSupplier = false
            };

            context.Organizations.AddOrUpdate(x => x.Name, organization);

            for (int i = 0; i < SeedData.Organizations.Length; i++)
            {
                context.Organizations.Add(SeedData.Organizations[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                var newOrganization = new Organization()
                {
                    Name = $"Customers - {i}",
                    MateriallyResponsiblePerson = "Pesho Peshov",
                    Address = "Sofia",
                    Vat = this.random.RandomNumber(100000000, 999999999).ToString(),
                    IsSupplier = false
                };

                context.Organizations.Add(newOrganization);
            }

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

            var admin = new User()
            {
                UserName = "admin@site.com",
                Email = "admin@site.com",
                PasswordHash = this.PasswordHasher.HashPassword("admin"),
                FirstName = "Nikolay",
                LastName = "Georgiev",
                CreatedOn = DateTime.Now
            };

            var organization = context.Organizations.FirstOrDefault(o => o.Name == "VW-NG");
            if (organization != null)
            {
                admin.OrganizationId = organization.Id;
            }

            userManager.Create(admin);
            userManager.AddToRole(admin.Id, "Administrator");

            var organizations = context.Organizations.ToList();
            for (int i = 0; i < 10; i++)
            {
                var user = new User()
                {
                    Email = $"user{i}@site.com",
                    UserName = $"user{i}@site.com",
                    FirstName = $"user{i}",
                    LastName = $"Userov{i}",
                    CreatedOn = DateTime.Now,
                    Organization = organizations[this.random.RandomNumber(0, organizations.Count - 1)]
                };

                this.userManager.Create(user, "123456");
            }

            context.SaveChanges();
        }
    }
}
