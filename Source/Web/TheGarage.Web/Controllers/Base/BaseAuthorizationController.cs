using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarage.Data.Models;
using TheGarage.Services.Data.Contracts;

namespace TheGarage.Web.Controllers.Base
{
    public class BaseAuthorizationController : BaseController
    {
        public BaseAuthorizationController(IUsersService usersService)
        {
            this.UsersService = usersService;
            this.SetCurrentUser();
        }

        protected IUsersService UsersService { get; private set; }

        protected User CurrentUser { get; private set; }

        private void SetCurrentUser()
        {
            var username = HttpContext.Current.User.Identity.Name;
            if (username != null)
            {
                this.CurrentUser = this.UsersService
                    .ByUsername(username)
                    .FirstOrDefault();
            }
        }
    }
}