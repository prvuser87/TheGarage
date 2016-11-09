namespace TheGarage.Web.Controllers.Base
{
    using Data;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Abstract controller used to provide uow to its successors.
    /// </summary>
    [MainGaragesActionFilter]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            // Work with data before BeginExecute to prevent "NotSupportedException: A second operation started on this context before a previous asynchronous operation completed."

            //this.ViewBag.MainCategories =
            //    this.data.ContestCategories.All()
            //        .Where(x => x.IsVisible && !x.ParentId.HasValue)
            //        .OrderBy(x => x.OrderBy)
            //        .Select(CategoryMenuItemViewModel.FromCategory);

            // Calling BeginExecute before PrepareSystemMessages for the TempData to has values
            var result = base.BeginExecute(requestContext, callback, state);

            return result;
        }

        protected ActionResult ConditionalActionResult<T>(Func<T> funcToPerform, Func<T, ActionResult> resultToReturn)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = funcToPerform();
                    return resultToReturn(result);
                }
                catch (Exception ex)
                {
                    return this.HttpNotFound(ex.Message);
                }
            }

            else
            {
                return this.HttpNotFound(ModelState.Values.FirstOrDefault().ToString());
            }
        }

        protected ActionResult IndependentActionResult(Action actionToPerform, ActionResult resultToReturn)
        {
            try
            {
                actionToPerform();
                return resultToReturn;
            }
            catch (Exception ex)
            {
                return this.HttpNotFound(ex.Message);
            }
        }

        protected ActionResult RedirectToAction<TCtrl>(Expression<Action<TCtrl>> expression, object routeValues = null)
            where TCtrl : Controller
        {
            var ctrl = typeof(TCtrl).Name.Replace("Controller", "");

            var action = ((MethodCallExpression)expression.Body).Method.Name;

            return this.RedirectToAction(action, ctrl, routeValues);
        }

        protected ActionResult RedirectToActionPermanent<TCtrl>(Expression<Action<TCtrl>> expression, object routeValues = null)
            where TCtrl : Controller
        {
            var ctrl = typeof(TCtrl).Name.Replace("Controller", "");

            var action = ((MethodCallExpression)expression.Body).Method.Name;

            return this.RedirectToActionPermanent(action, ctrl, routeValues);
        }
    }
}