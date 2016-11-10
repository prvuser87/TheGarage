using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarage.Services.Common.Administration
{
    public interface IUserRoleAdministrationService : IService
    {
        void Create(IdentityRole entity);

        void Delete(object id);

        void Update(IdentityRole entity);

        IEnumerable<IdentityRole> Read();

        IdentityRole Get(object id);
    }
}
