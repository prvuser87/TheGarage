namespace TheGarage.Web.Areas.Administration.ViewModels.Roles
{
    using AutoMapper.SelfConfig;
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class UserInRoleAdministrationViewModel : IMapFrom<User>, IMapTo<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}