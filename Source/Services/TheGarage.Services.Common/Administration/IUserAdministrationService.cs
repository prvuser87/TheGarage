namespace TheGarage.Services.Common.Administration
{
    using System.Collections.Generic;

    using Data.Common.Models;
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IUserAdministrationService : IService
    {
        void Create(User entity);

        void Delete(object id);

        void Update(User entity);

        IEnumerable<User> Read();

        void AddUserToRole(IdentityUserRole entity);

        User Get(object id);

        IEnumerable<User> GetAllUsersByRoleId(string id);
    }
}
