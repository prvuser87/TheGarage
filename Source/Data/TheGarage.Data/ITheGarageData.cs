namespace TheGarage.Data
{
    using System.Data.Entity;
    using TheGarage.Data.Common.Repositories;
    using TheGarage.Data.Models;

    public interface ITheGarageData
    {
        IDeletableEntityRepository<User> Users { get; }

        DbContext Context { get; }

        void SaveChanges();
    }
}
