namespace TheGarage.Data
{
    using System.Data.Entity;
    using Common.Repositories;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface ITheGarageData
    {
        IRepository<IdentityUserRole> UserRole { get; }

        IRepository<IdentityRole> Roles { get; }

        IDeletableEntityRepository<User> Users { get; }

        IDeletableEntityRepository<AccessLog> AccessLogs { get; }

        IDeletableEntityRepository<Client> Clients { get; }

        IDeletableEntityRepository<Company> Companies { get; }

        IDeletableEntityRepository<Garage> Garages { get; }

        IDeletableEntityRepository<GeneratedPassword> GeneratedPasswords { get; }

        IDeletableEntityRepository<Promotion> Promotions { get; }

        IDeletableEntityRepository<RequestedGarage> RequestedGarages { get; }

        IDeletableEntityRepository<Transaction> Transactions { get; }

        DbContext Context { get; }

        void SaveChanges();
    }
}
