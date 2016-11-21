using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Common.Models;

namespace TheGarage.Data.Models
{
    public class State : DeletableEntity
    {
        private ICollection<City> cities;

        public State()
        {
            this.Id = Guid.NewGuid();
            this.cities = new HashSet<City>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }
}
