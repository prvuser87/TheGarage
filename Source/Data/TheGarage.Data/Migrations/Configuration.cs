namespace TheGarage.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    using Models;
    using TheGarage.Common;

    public sealed class Configuration : DbMigrationsConfiguration<TheGarageDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheGarageDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdmin(context);
            this.SeedModerator(context);
            this.SeedUsers(context);
            this.SeedData(context);
        }

        private void SeedData(TheGarageDbContext context)
        {
            if (context.AccessLogs.Any())
            {
                return;
            }

            var ipAddresses = new[] { "192.168.0.1", "192.168.0.2", "192.168.0.3", "192.168.0.4", "192.168.0.5", "192.168.0.6", "192.168.0.7", "8" };

            foreach (string ipAddress in ipAddresses)
            {
                context.AccessLogs.AddOrUpdate(t => t.IpAddress, this.NewAccessLog(ipAddress, "POST", "www.parxSIS"));
            }

            context.SaveChanges();
        }

        private void SeedUsers(TheGarageDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            var names = GetUserNames();

            var userManager = new UserManager<User>(new UserStore<User>(context));

            for (int i = 0; i < names.Length; i++)
            {
                var user = new User()
                {
                    UserName = string.Format("FakeUser{0}", i + 1),
                    Email = string.Format("FakeUser{0}@FakeEmail.com", i + 1),
                    FirstName = names[i].Substring(0, names[i].IndexOf(" ")),
                    LastName = names[i].Substring(names[i].IndexOf(" ") + 1)
                };

                userManager.Create(user, "qwerty");

                userManager.AddToRole(user.Id, GlobalConstants.DefaultRole);

                context.SaveChanges();
            }
        }

        private void SeedModerator(TheGarageDbContext context)
        {
            const string ModeratorEmail = "moderator@moderator.com";
            const string ModeratorPassword = "moderator123456";

            if (context.Users.Any(u => u.Email == ModeratorEmail))
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            var admin = new User
            {
                FirstName = "Gosho",
                LastName = "Moderatora",
                Email = ModeratorEmail,
                UserName = ModeratorEmail
            };

            userManager.Create(admin, ModeratorPassword);

            userManager.AddToRole(admin.Id, GlobalConstants.ModeratorRole);
            userManager.AddToRole(admin.Id, GlobalConstants.DefaultRole);

            context.SaveChanges();
        }

        private void SeedAdmin(TheGarageDbContext context)
        {
            const string AdminEmail = "qwe@qwe.com";
            const string AdminPassword = "qweqwe";

            if (context.Users.Any(u => u.Email == AdminEmail))
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            var admin = new User
            {
                FirstName = "Pesho",
                LastName = "Admina",
                Email = AdminEmail,
                UserName = AdminEmail
            };

            userManager.Create(admin, AdminPassword);
            userManager.AddToRole(admin.Id, GlobalConstants.AdminRole);
            userManager.AddToRole(admin.Id, GlobalConstants.ModeratorRole);
            userManager.AddToRole(admin.Id, GlobalConstants.DefaultRole);

            context.SaveChanges();
        }

        private void SeedRoles(TheGarageDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole { Name = GlobalConstants.DefaultRole });
            roleManager.Create(new IdentityRole { Name = GlobalConstants.AdminRole });
            roleManager.Create(new IdentityRole { Name = GlobalConstants.ModeratorRole });

            context.SaveChanges();
        }

        private AccessLog NewAccessLog(string ipAddress, string requestType, string url)
        {
            return new AccessLog
            {
                IpAddress = ipAddress,
                RequestType = requestType,
                Url = url
            };
        }

        private string[] GetUserNames()
        {
            return new[]
            {
                "Polly Dimitrova",
                "Petur Toshev",
                "Aleksii Todorov",
                "Dimitur Stoyanov",
                "Anna Georgieva",
                "Viktor Ivanov",
                "Vicktoria Petrova",
                "Sara Merkenzel",
                "Gosho Petrov",
                "Pesho Georgiev",
                "Ivan Klisurski",
                "Matt Deamon",
                "Peter Stoyanov",
                "Dragomir Petrov",
                "Dimitur Trifonov"
            };
        }
    }
}

