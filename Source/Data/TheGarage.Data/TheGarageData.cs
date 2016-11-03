namespace TheGarage.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Common.Models;
    using Common.Repositories;
    using Models;

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

        public IDeletableEntityRepository<AccessLog> AccessLogs
        {
            get
            {
                return this.GetRepository<AccessLog>();
            }
        }

        public IDeletableEntityRepository<Client> Clients
        {
            get
            {
                return this.GetRepository<Client>();
            }
        }

        public IDeletableEntityRepository<Company> Companies
        {
            get
            {
                return this.GetRepository<Company>();
            }
        }

        public IDeletableEntityRepository<GeneratedPassword> GeneratedPasswords
        {
            get
            {
                return this.GetRepository<GeneratedPassword>();
            }
        }

        public IDeletableEntityRepository<Promotion> Promotions
        {
            get
            {
                return this.GetRepository<Promotion>();
            }
        }

        public IDeletableEntityRepository<RequestedGarage> RequestedGarages
        {
            get
            {
                return this.GetRepository<RequestedGarage>();
            }
        }

        public IDeletableEntityRepository<Transaction> Transactions
        {
            get
            {
                return this.GetRepository<Transaction>();
            }
        }

        public IDeletableEntityRepository<Garage> Garages
        {
            get
            {
                return this.GetRepository<Garage>();
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
