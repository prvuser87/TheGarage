namespace TheGarage.Services.Users
{
    using Common.Users;
    using System.Linq;

    using TheGarage.Data;
    using TheGarage.Data.Models;

    public class UserProfileService : IUserProfileService
    {
        private ITheGarageData data;

        public UserProfileService(ITheGarageData data)
        {
            this.data = data;
        }

        public IQueryable<User> GetUserProfile(string userId)
        {
            return this.data.Users.All().Where(u => u.Id == userId && !u.IsHidden);
        }

        public string UpdateUserProfile(string userId, UserUpdateProfileModel model)
        {
            var user = this.data.Users.GetById(userId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            this.data.Users.Update(user);
            this.data.SaveChanges();

            return user.Id;
        }
    }
}
