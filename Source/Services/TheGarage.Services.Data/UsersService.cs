using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data.Common.Repositories;
using TheGarage.Data.Models;
using TheGarage.Services.Data.Contracts;

namespace TheGarage.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;
        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> ByUsername(string username)
        {
            return this.users
                .All()
                .Where(u => u.UserName == username);
        }

        public void UpdateUser(
             User user,
             string FirstName,
             string LastName,
             string City,
             string Phone,
             string About)
        {

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.City = City;
            user.Phone = Phone;
            user.About = About;

            this.users.Update(user);
            this.users.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            this.users.Delete(user);
            this.users.SaveChanges();
        }

        public IQueryable<User> QueriedAllUsers()
        {
            var query = this.users
                .All()
                .Where(p => !p.IsHidden);
            return query;
        }

        public User FindUserById(string key)
        {
            return this.users
                .All()
                .FirstOrDefault(k => k.Id == key);
        }

        public User Account(string emailOrUser, string password)
        {
            //var remoteUser = await this.remoteData.Login(username, password);
            //if (remoteUser == null)
            //{
            //    return null;
            //}

            var localUser = this.GetLocalAccount(emailOrUser);

            //if (localUser == null)
            //{
            //    localUser = new User
            //    {
            //        UserName = remoteUser.UserName
            //        //AvatarUrl = remoteUser.AvatarUrl,
            //        //IsAdmin = remoteUser.IsAdmin
            //    };

            //    this.users.Add(localUser);
            //    this.users.SaveChanges();
            //}
            //else if (localUser.AvatarUrl != remoteUser.AvatarUrl || localUser.IsAdmin != remoteUser.IsAdmin)
            //{
            //    localUser.IsAdmin = remoteUser.IsAdmin;
            //    localUser.AvatarUrl = remoteUser.AvatarUrl;
            //    this.users.SaveChanges();
            //}

            return localUser;
        }

        private User GetLocalAccount(string emailOrUserName)
        {
            return this.users
                .All()
                .FirstOrDefault(u => u.Email == emailOrUserName || u.UserName == emailOrUserName);
        }
    }
}
