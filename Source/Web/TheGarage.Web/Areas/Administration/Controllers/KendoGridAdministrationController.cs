//namespace TheGarage.Web.Areas.Administration.Controllers
//{
//    using System;
//    using System.Collections;
//    using System.Data.Entity;
//    using System.Linq;
//    using System.Web.Mvc;

//    using Kendo.Mvc.UI;
//    using Kendo.Mvc.Extensions;

//    using AutoMapper;
//    using AutoMapper.QueryableExtensions;

//    using TheGarage.Data.Common.Models;
//    using TheGarage.Web.Areas.Administration.ViewModels;
//    using TheGarage.Services.Common.Administration;
//    using TheGarage.Web.Infrastructure.Caching;

//    public abstract class KendoGridAdministrationController<TDbModel, TViewModel> : AdminController
//        where TDbModel : IDeletableEntity
//        where TViewModel : AdministrationViewModel
//    {
//        private readonly IAdministrationService<TDbModel> administrationService;

//        public KendoGridAdministrationController(IAdministrationService<TDbModel> administrationService)
//        {
//            this.administrationService = administrationService;
//        }

//        protected IAdministrationService<TDbModel> AdministrationService
//        {
//            get { return this.administrationService; }
//        }

//        [HttpPost]
//        public virtual ActionResult Read([DataSourceRequest]DataSourceRequest request, Guid? id = null)
//        {
//            var data = this.administrationService
//                .Read()
//                .AsQueryable()
//                .ProjectTo<TViewModel>()
//                .ToDataSourceResult(request);

//            return this.Json(data);
//        }

//        [NonAction]
//        protected virtual void Update(TViewModel model)
//        {
//            if (model != null && ModelState.IsValid)
//            {
//                var dbModel = this.administrationService.Get(model.Id);
//                Mapper.Map<TViewModel, TDbModel>(model, dbModel);
//                this.administrationService.Update(dbModel);
//            }
//        }

//        [NonAction]
//        protected virtual void Destroy(object id)
//        {
//            this.administrationService.Delete(id);
//        }

//        [NonAction]
//        protected virtual void Destroy(TViewModel model)
//        {
//            if (model != null && ModelState.IsValid)
//            {
//                this.administrationService.Delete(model.Id);
//            }
//        }

//        protected JsonResult GridOperation(TViewModel model, [DataSourceRequest]DataSourceRequest request)
//        {
//            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
//        }
//    }
//}