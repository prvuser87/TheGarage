﻿namespace TheGarage.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Common.Models;


    public class Client : DeletableEntity
    {
        private ICollection<Transaction> transactions;

        public Client()
        {
            this.Id = Guid.NewGuid();
            this.transactions = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }

        public bool IsApproved { get; set; }

        public Guid GarageId { get; set; }

        public virtual Garage Garage { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
        
        public Guid PromotionId { get; set; }

        public virtual Promotion Promotion { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
