using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheGarage.Data;

namespace TheGarage.Web
{
    public class HasPermissionAttribute : ActionFilterAttribute
    {
        private string _permission;

        [Inject]
        public ITheGarageData Data { get; set; }

        public HasPermissionAttribute(string permission)
        {
            this._permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!CHECK_IF_USER_OR_ROLE_HAS_PERMISSION(_permission))
            {
                // If this user does not have the required permission then redirect to login page
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = url.Content("/Account/Login");
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }

        private bool CHECK_IF_USER_OR_ROLE_HAS_PERMISSION(string _permission)
        {
            
            var currentLoggedUser = HttpContext.Current.User.Identity.Name;
            var allLoggedUserRoles = System.Web.Security.Roles.Provider.GetRolesForUser(currentLoggedUser);
            var permission = this.Data.HasPermissions.All().Where(u => u.Name == _permission);
            var hasPermissionLoggedUser = false;

            foreach (var role in allLoggedUserRoles)
            {
                hasPermissionLoggedUser = permission.Any(u => u.ApplicationRole.Name == role);
                if (hasPermissionLoggedUser)
                {
                    return true;
                }
            }

            return hasPermissionLoggedUser;
        }
    }
}
