namespace TheGarage.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Common.Models;

    public class Promotion : DeletableEntity
    {
        private ICollection<Client> client;

        public Promotion()
        {
            this.Id = Guid.NewGuid();
            this.client = new HashSet<Client>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal DiscountInPercent { get; set; }

        public string DiscountCode { get; set; }

        public DateTime DiscountStartTime { get; set; }

        public DateTime DiscountEndTime { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
