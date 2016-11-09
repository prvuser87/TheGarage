﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;
using TheGarage.Common;
using TheGarage.Data.Models;
using TheGarage.Services.Common.Administration;
using TheGarage.Web.Areas.Administration.ViewModels.Roles;
using Model = Microsoft.AspNet.Identity.EntityFramework.IdentityRole;
using ViewModel = TheGarage.Web.Areas.Administration.ViewModels.Roles.RoleAdministrationViewModel;
using ViewModelType = TheGarage.Web.Areas.Administration.ViewModels.Roles.UserInRoleAdministrationViewModel;

namespace TheGarage.Web.Areas.Administration.Controllers
{
    public class RolesController : AdminController
    {
        private readonly IUserRoleAdministrationService userRoleAdministrationService;
        private readonly IUserAdministrationService userAdministrationService;

        public RolesController(IUserRoleAdministrationService userRoleAdministrationService, IUserAdministrationService userAdministrationService)
        {
            this.userRoleAdministrationService = userRoleAdministrationService;
            this.userAdministrationService = userAdministrationService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.userRoleAdministrationService
                .Read()
                .AsQueryable()
                .ProjectTo<ViewModel>();

            var serializationSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(data.ToDataSourceResult(request), Formatting.None, serializationSettings);
            return this.Content(json, GlobalConstants.JsonMimeType);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                model.RoleId = Guid.NewGuid().ToString();

                var dbmodel = Mapper.Map<Model>(model);

                this.userRoleAdministrationService.Create(dbmodel);
            }

            return this.GridOperation(model, request);
        }

        //[HttpPost]
        //public ActionResult Read(DataSourceRequest request, Guid? Id = null)
        //{
        //    var data = this.userRoleAdministrationService.Read().AsQueryable();

        //    //if (commentId.HasValue)
        //    //{
        //    //    data = data.Where(c => c.CommentId == commentId.Value);
        //    //}

        //    return this.Json(data.ProjectTo<ViewModel>().ToDataSourceResult(request));
        //}

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {


            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.userRoleAdministrationService.Get(model.RoleId);
                Mapper.Map<ViewModel, Model>(model, dbModel);
                this.userRoleAdministrationService.Update(dbModel);
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.userRoleAdministrationService.Delete(model.RoleId);
            }

            return this.GridOperation(model, request);
        }



        [HttpPost]
        public JsonResult UsersInRole([DataSourceRequest]DataSourceRequest request, string id)
        {
            var users = this.userAdministrationService.GetAllUsersByRoleId(id);

            return this.Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AvailableUsersForRole(string text)
        {
            var users = this.userAdministrationService.Read();

            if (!string.IsNullOrEmpty(text))
            {
                users = users.Where(u => u.UserName.ToLower().Contains(text.ToLower()));
            }

            var result = users
                .ToList()
                .Select(pr => new SelectListItem
                {
                    Text = pr.UserName,
                    Value = pr.Id,
                });

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddUserToRole([DataSourceRequest]DataSourceRequest request, string id, string userId)
        {
            var user = this.userAdministrationService.Get(userId);
            var role = this.userRoleAdministrationService.Read().FirstOrDefault(r => r.Id == id);

            var userToRole = new IdentityUserRole();

            userToRole.RoleId = role.Id;
            userToRole.UserId = userId;

            this.userAdministrationService.AddUserToRole(userToRole);

            var result = new UserInRoleAdministrationViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return this.Json(new[] { result }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteUserFromRole([DataSourceRequest]DataSourceRequest request, string id, ViewModelType model)
        {
            var user = this.userAdministrationService.Get(model.Id);
            var role = this.userRoleAdministrationService.Read().FirstOrDefault(r => r.Id == id);

            this.userRoleAdministrationService.Delete(role);

            return this.Json(this.ModelState.ToDataSourceResult());
        }

        protected JsonResult GridOperation(ViewModel model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}