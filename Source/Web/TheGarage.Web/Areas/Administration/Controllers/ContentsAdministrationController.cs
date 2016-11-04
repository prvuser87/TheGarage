//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace TheGarage.Web.Areas.Administration.Controllers
//{
//    using System.Web.Mvc;

//    using Kendo.Mvc.UI;

//    using TheGarage.Data.Models;
//    using TheGarage.Services.Common.Administration;
//    using TheGarage.Web.Areas.Administration.ViewModels;
//    using TheGarage.Web.Infrastructure.Caching;

//    using Model = TheGarage.Data.Models.Content;
//    using ViewModel = TheGarage.Web.Areas.Administration.ViewModels.ContentAdministrationViewModel;

//    public class ContentsAdministrationController : KendoGridAdministrationController<Model, ViewModel>
//    {
//        private readonly ICacheService cache;

//        public ContentsAdministrationController(IAdministrationService<Model> administrationService, ICacheService cache)
//            : base(administrationService)
//        {
//            this.cache = cache;
//        }

//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
//        {
//            base.Update(model);
//            this.cache.Clear(model.Id);
//            return this.GridOperation(model, request);
//        }

//        [HttpPost]
//        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
//        {
//            base.Destroy(model);
//            this.cache.Clear(model.Id);
//            return this.GridOperation(model, request);
//        }
//    }
//}