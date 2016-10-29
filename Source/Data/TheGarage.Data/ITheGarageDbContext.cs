namespace TheGarage.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TheGarage.Data.Models;

    public interface ITheGarageDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        IDbSet<User> Users { get; set; }

        DbContext DbContext { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
