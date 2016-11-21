using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Common.Models;

namespace TheGarage.Data.Models
{
    public class HasPermission : DeletableEntity
    {
        public HasPermission()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ApplicationRoleId { get; set; }

        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
