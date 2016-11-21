namespace TheGarage.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Common.Models;
    using Common.Repositories;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Web.Configuration;

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
                return this.GetDeletableEntityRepository<User>();
            }
        }


        public IDeletableEntityRepository<AccessLog> AccessLogs
        {
            get
            {
                return this.GetDeletableEntityRepository<AccessLog>();
            }
        }

        public IDeletableEntityRepository<State> States
        {
            get
            {
                return this.GetDeletableEntityRepository<State>();
            }
        }

        public IDeletableEntityRepository<City> Cities
        {
            get
            {
                return this.GetDeletableEntityRepository<City>();
            }
        }

        public IDeletableEntityRepository<Client> Clients
        {
            get
            {
                return this.GetDeletableEntityRepository<Client>();
            }
        }

        public IRepository<ApplicationRole> Roles
        {
            get
            {
                return this.GetRepository<ApplicationRole>();
            }
        }

        public IDeletableEntityRepository<HasPermission> HasPermissions
        {
            get
            {
                return this.GetDeletableEntityRepository<HasPermission>();
            }
        }

        public IDeletableEntityRepository<Company> Companies
        {
            get
            {
                return this.GetDeletableEntityRepository<Company>();
            }
        }

        public IDeletableEntityRepository<GeneratedPassword> GeneratedPasswords
        {
            get
            {
                return this.GetDeletableEntityRepository<GeneratedPassword>();
            }
        }

        public IDeletableEntityRepository<Promotion> Promotions
        {
            get
            {
                return this.GetDeletableEntityRepository<Promotion>();
            }
        }

        public IDeletableEntityRepository<RequestedGarage> RequestedGarages
        {
            get
            {
                return this.GetDeletableEntityRepository<RequestedGarage>();
            }
        }

        public IDeletableEntityRepository<Transaction> Transactions
        {
            get
            {
                return this.GetDeletableEntityRepository<Transaction>();
            }
        }

        public IDeletableEntityRepository<Garage> Garages
        {
            get
            {
                return this.GetDeletableEntityRepository<Garage>();
            }
        }


        public T GetDbContext<T>() where T : DbContext, ITheGarageDbContext
        {
            return this.context as T;
        }


        //public IRepository<IdentityUserRole> UserRole
        //{
        //    get
        //    {
        //        return this.GetRepository<IdentityUserRole>();
        //    }
        //}

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

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfGenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }


        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
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
