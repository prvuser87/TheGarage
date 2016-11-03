namespace TheGarage.Data.Common.Repositories
{
    using System.Linq;

    using TheGarage.Data.Common.Models;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class, IDeletableEntity
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);
    }
}