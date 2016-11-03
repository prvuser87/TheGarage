namespace TheGarage.Data.Models
{
    using System;

    using TheGarage.Data.Common.Models;

    public class AccessLog : DeletableEntity
    {
        public AccessLog()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string IpAddress { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string RequestType { get; set; }

        public string Url { get; set; }

        public string PostParams { get; set; }

    }
}
