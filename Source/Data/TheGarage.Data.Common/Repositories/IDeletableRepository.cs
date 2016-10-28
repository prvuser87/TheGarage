using TheGarage.Data.Common.Models;

namespace TheGarage.Data.Common.Repositories
{
    using System.Linq;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class, IDeletableEntity
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);
    }
}