using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Models;

namespace TheGarage.Services.Common.Administration
{
    public interface IClientAdministrationService
    {
        void Create(Client entity);

        void Delete(object id);

        void Update(Client entity);

        IEnumerable<Client> Read();

        Client Get(object id);
    }
}
