using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Data;
using TheGarage.Data.Common.Repositories;
using TheGarage.Data.Models;
using TheGarage.Services.Common.Extensions;
using TheGarage.Services.Data.Contracts;

namespace TheGarage.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly ITheGarageData data;
        public UsersService(ITheGarageData data)
        {
            this.data = data;
        }

        public IQueryable<User> ByUsername(string username)
        {
            //this.data.ChangeDatabaseTo("ForDelTestOnly");
            return this.data
                .Users
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

            this.data.Users.Update(user);
            this.data.Users.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            this.data.Users.Delete(user);
            this.data.Users.SaveChanges();
        }

        public IQueryable<User> QueriedAllUsers()
        {
            var query = this.data
                .Users
                .All()
                .Where(p => !p.IsHidden);
            return query;
        }

        public User FindUserById(string key)
        {
            return this.data
                .Users
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
            return this.data
                .Users
                .All()
                .FirstOrDefault(u => u.Email == emailOrUserName || u.UserName == emailOrUserName);
        }
    }
}
