using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Common.Models;

namespace TheGarage.Data.Models
{
    public class ApplicationRole : IdentityRole, IDeletableEntity
    {
        private ICollection<HasPermission> hasPermissions;

        public ApplicationRole() : base()
        {
            this.CreatedOn = DateTime.Now;
            this.hasPermissions = new HashSet<HasPermission>();
        }

        public ApplicationRole(string name) : base(name) { }

        public ICollection<HasPermission> HasPermissions { get; set; }

        // IAuditInfo
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsHidden { get; set; }

        // IDeletableEntity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
