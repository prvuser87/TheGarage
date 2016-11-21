using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Common.Models;

namespace TheGarage.Data.Models
{
    public class City : DeletableEntity
    {
        private ICollection<Garage> garages;

        public City()
        {
            this.garages = new HashSet<Garage>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int ZipCode { get; set; }

        public Guid StateId { get; set; }

        public State States { get; set; }

        public ICollection<Garage> Garages { get; set; }
    }
}
