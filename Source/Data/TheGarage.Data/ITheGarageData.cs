namespace TheGarage.Data
{
    using System.Data.Entity;
    using Common.Repositories;
    using Models;

    public interface ITheGarageData
    {
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
