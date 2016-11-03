namespace TheGarage.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class RequestedGarage : DeletableEntity
    {
        private ICollection<User> users;

        public RequestedGarage()
        {
            this.Id = Guid.NewGuid();
            this.users = new HashSet<User>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
