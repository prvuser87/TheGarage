using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGarage.Services.Data.Contracts;

namespace TheGarage.Web.Controllers.Base
{
    public class BaseController
    {
        public BaseController(IUsersService usersService)
        {
            this.UsersService = usersService;
        }

        protected IUsersService UsersService { get; private set; }

        
    }
}