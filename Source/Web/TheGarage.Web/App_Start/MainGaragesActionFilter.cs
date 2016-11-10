namespace TheGarage.Web
{
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Models;
    using Ninject;
    using System.Linq;
    using System.Web.Mvc;

    using TheGarage.Data;

    public class MainGaragesActionFilter : ActionFilterAttribute
    {


        [Inject]
        public ITheGarageData Data { get; set; }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.MainGarages = this.Data.Garages
                .All()
                .ProjectTo<GarageMenuItemViewModel>();
            //.Where(x => x.IsVisible && !x.ParentId.HasValue)
            //.OrderBy(x => x.OrderBy)
            base.OnActionExecuting(filterContext);

        }
    }
}