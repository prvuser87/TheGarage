using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Models;

namespace TheGarage.Services.Common.Administration
{
    public interface IGarageAdministrationService
    {
        void Create(Garage entity);

        void Delete(object id);

        void Update(Garage entity);

        IEnumerable<Garage> Read();

        Garage Get(object id);
    }
}
