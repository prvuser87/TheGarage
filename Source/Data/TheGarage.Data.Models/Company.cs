namespace TheGarage.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Common.Models;

    public class Company : DeletableEntity
    {
        private ICollection<Garage> garages;

        public Company()
        {
            this.Id = Guid.NewGuid();
            this.garages = new HashSet<Garage>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }

        public string Description { get; set; }

        public ICollection<Garage> Garages { get; set; }
    }
}