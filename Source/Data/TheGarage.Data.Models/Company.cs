namespace TheGarage.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Common.Models;

    public class Company : DeletableEntity
    {
        private ICollection<State> states;

        public Company()
        {
            this.Id = Guid.NewGuid();
            this.states = new HashSet<State>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<State> States { get; set; }
    }
}