namespace TheGarage.Services.Administration
{
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity.EntityFramework;

    using TheGarage.Data;
    using TheGarage.Services.Common.Administration;
    using Data.Models;

    public class UserRoleAdministrationService : BaseAdministrationService, IUserRoleAdministrationService
    {
        public UserRoleAdministrationService(ITheGarageData data)
            : base(data)
        {
        }

        public void Create(ApplicationRole entity)
        {
            this.Data.Roles.Add(entity);
            this.Data.SaveChanges();
        }

        public void Delete(object id)
        {
            var content = this.Data.Roles.GetById(id);

            this.Data.SaveChanges();
        }

        public ApplicationRole Get(object id)
        {
            return this.Data.Roles.GetById(id);
        }

        public IEnumerable<ApplicationRole> Read()
        {
            return this.Data.Roles.All();
        }

        public void Update(ApplicationRole entity)
        {
            this.Data.Roles.Update(entity);
            this.Data.SaveChanges();
        }
    }
}
