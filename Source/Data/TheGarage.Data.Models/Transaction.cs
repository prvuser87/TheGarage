namespace TheGarage.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Transaction : DeletableEntity
    {
        public Transaction()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public bool TransactionStatus { get; set; }

        public bool CardStatus { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
