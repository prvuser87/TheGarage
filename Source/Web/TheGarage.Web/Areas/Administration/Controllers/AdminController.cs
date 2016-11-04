namespace TheGarage.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using TheGarage.Common;
    using Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
    }
}