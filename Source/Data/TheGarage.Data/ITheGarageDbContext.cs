namespace TheGarage.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface ITheGarageDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        IDbSet<User> Users { get; set; }

        IDbSet<AccessLog> AccessLogs { get; set; }

        IDbSet<Client> Clients { get; set; }

        IDbSet<Company> Companies { get; set; }

        IDbSet<Garage> Garages { get; set; }

        IDbSet<GeneratedPassword> GeneratedPasswords { get; set; }

        IDbSet<Promotion> Promotions { get; set; }

        IDbSet<RequestedGarage> RequestedGarages { get; set; }

        IDbSet<Transaction> Transactions { get; set; }

        DbContext DbContext { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
