using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Models;

namespace TheGarage.Services.Common.Administration
{
    public interface ICompanyAdministrationService
    {
        void Create(Company entity);

        void Delete(object id);

        void Update(Company entity);

        IEnumerable<Company> Read();

        Company Get(object id);
    }
}
