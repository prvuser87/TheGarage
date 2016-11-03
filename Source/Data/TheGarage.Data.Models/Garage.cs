namespace TheGarage.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Garage : DeletableEntity
    {
        private ICollection<Client> clients;
        private ICollection<GeneratedPassword> generatedPasswords;

        public Garage()
        {
            this.Id = Guid.NewGuid();
            this.clients = new HashSet<Client>();
            this.generatedPasswords = new HashSet<GeneratedPassword>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime BillingDate { get; set; }

        public DateTime GracePeriod { get; set; }

        public float GoogleMapLat { get; set; }
    
        public float GoogleMapLng { get; set; }

        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<GeneratedPassword> GeneratedPasswords { get; set; }
    }
}
