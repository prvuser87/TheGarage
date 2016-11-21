using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Models;

namespace TheGarage.Services.Common.Administration
{
    public interface IUserRoleAdministrationService
    {
        void Create(ApplicationRole entity);

        void Delete(object id);

        void Update(ApplicationRole entity);

        IEnumerable<ApplicationRole> Read();

        ApplicationRole Get(object id);
    }
}
