using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Models;
using TheGarage.Services.Common;

namespace TheGarage.Services.Data.Contracts
{
    public interface IUsersService : IService
    {
        IQueryable<User> ByUsername(string username);

        IQueryable<User> QueriedAllUsers();

        User Account(string emailOrUserName, string password);

        User FindUserById(string key);

        void DeleteUser(User user);

        void UpdateUser(
            User user,
            string FirstName,
            string LastName,
            string City,
            string Phone,
            string About);

    }
}
