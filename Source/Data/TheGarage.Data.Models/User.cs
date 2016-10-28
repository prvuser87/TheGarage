using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Common.Models;

namespace TheGarage.Data.Models
{
    public class User : IdentityUser, IDeletableEntity
    {

        public User()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;
        }

        [MaxLength(100)]
        [MinLength(2)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string About { get; set; }

        // IAuditInfo
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsHidden { get; set; }

        // IDeletableEntity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}

