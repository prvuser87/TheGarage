namespace TheGarage.Services.Common.Users
{
    using System.IO;
    using System.Linq;

    using TheGarage.Data.Models;

    public interface IUserProfileService
    {
        /// <summary>
        /// Gets the user model by id.
        /// </summary>
        /// <param name="userId">The id of the user to get.</param>
        /// <returns>User as queryable.</returns>
        IQueryable<User> GetUserProfile(string userId);

        /// <summary>
        /// Updates the profile of the user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="model">The new profile.</param>
        /// <returns>The Id of the user.</returns>
        string UpdateUserProfile(string userId, UserUpdateProfileModel model);
    }
}
