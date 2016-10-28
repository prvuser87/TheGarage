using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TheGarage.Data.Common.Models;
using TheGarage.Data.Models;

namespace TheGarage.Data
{
    public class TheGarageDbContext : IdentityDbContext<User>
    {
        public TheGarageDbContext()
            : base("TheGarage")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static TheGarageDbContext Create()
        {
            return new TheGarageDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            var changedAudits = this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in changedAudits)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
