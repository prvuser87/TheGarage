namespace TheGarage.Data.Models
{

    using System;

    using Common.Models;

    public class GeneratedPassword : DeletableEntity
    {
        public GeneratedPassword()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Password { get; set; }

        public Guid GarageId { get; set; }

        public virtual Garage Garage { get; set; }
    }
}
