namespace TheGarage.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using TheGarage.Data.Common.Models;
    using TheGarage.Data.Common.Repositories;
    using TheGarage.Data.Models;

    public class TheGarageData : ITheGarageData
    {
        private ITheGarageDbContext context;
        private IDictionary<Type, object> repositories;

        public static ITheGarageData Create(ITheGarageDbContext context)
        {
            return new TheGarageData(context);
        }

        public TheGarageData(ITheGarageDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public DbContext Context
        {
            get
            {
                return this.context.DbContext;
            }
        }

        public IDeletableEntityRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }
        
        public void SaveChanges()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        private IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeof(DeletableEntityRepository<T>), this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfModel];
        }
    }
}
