﻿namespace TheGarage.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using TheGarage.Services.Common.Administration;
    using TheGarage.Web.Infrastructure.Caching;

    using Model = TheGarage.Data.Models.User;
    using ViewModel = TheGarage.Web.Areas.Administration.ViewModels.Users.UsersAdministrationViewModel;

    public class UsersController : AdminController
    {
        private readonly IUserAdministrationService userAdministrationService;
        private readonly ICacheService cache;

        public UsersController(IUserAdministrationService userAdministrationService, ICacheService cache)
        {
            this.userAdministrationService = userAdministrationService;
            this.cache = cache;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.userAdministrationService
                .Read()
                .AsQueryable()
                .ProjectTo<ViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        //[HttpPost]
        //public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        //{
        //    var allInfluencedContent = this.userAdministrationService.UpdateUser(model.Id, model.IsCurrentlyAdmin, model.IsCurrentlyModerator, model.IsHidden);

        //    foreach (var item in allInfluencedContent)
        //    {
        //        this.cache.Clear(item);
        //    }

        //    return this.GridOperation(model, request);
        //}

        //[HttpPost]
        //public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        //{
        //    var allInfluencedContent = this.userAdministrationService.DeleteUser(model.Id);

        //    foreach (var item in allInfluencedContent)
        //    {
        //        this.cache.Clear(item);
        //    }

        //    return this.GridOperation(model, request);
        //}

        protected JsonResult GridOperation(ViewModel model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}