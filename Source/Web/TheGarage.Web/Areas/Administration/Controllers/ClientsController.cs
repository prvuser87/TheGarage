using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using TheGarage.Common;
using TheGarage.Services.Common.Administration;
using TheGarage.Web.Areas.Administration.ViewModels.Clients;
using Model = TheGarage.Data.Models.Client;
using ViewModel = TheGarage.Web.Areas.Administration.ViewModels.Clients.ClientAdministrationViewModel;
using AutoMapper;

namespace TheGarage.Web.Areas.Administration.Controllers
{
    public class ClientsController : AdminController
    {
        private readonly IClientAdministrationService clientAdministrationService;
        private readonly IGarageAdministrationService garageAdministrationService;
        private readonly IUserAdministrationService userAdministrationService;

        public ClientsController(IClientAdministrationService clientAdministrationService, IGarageAdministrationService garageAdministrationService, IUserAdministrationService userAdministrationService)
        {
            this.clientAdministrationService = clientAdministrationService;
            this.garageAdministrationService = garageAdministrationService;
            this.userAdministrationService = userAdministrationService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Contest(int id)
        {
            return this.View(id);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.clientAdministrationService
                .Read()
                .AsQueryable()
                .ProjectTo<ViewModel>();

            var serializationSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(data.ToDataSourceResult(request), Formatting.None, serializationSettings);
            return this.Content(json, GlobalConstants.JsonMimeType);
        }

        public ActionResult ReadClients([DataSourceRequest]DataSourceRequest request, Guid? id)
        {
            if (id == null)
            {
                return this.Read(request);
            }

            var clients = this.clientAdministrationService
                .Read()
                .Where(p => p.GarageId == id)
                .AsQueryable()
                .ProjectTo<ViewModel>();

            var serializationSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(clients.ToDataSourceResult(request), Formatting.None, serializationSettings);
            return this.Content(json, GlobalConstants.JsonMimeType);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var garage = this.garageAdministrationService.Read().FirstOrDefault(c => c.Id == model.GarageId);
            var user = this.userAdministrationService.Read().FirstOrDefault(u => u.Id == model.UserId);

            if (garage == null || user == null)
            {
                if (garage == null)
                {
                    this.ModelState.AddModelError("GarageId", "Invalid_garage");
                }

                if (user == null)
                {
                    this.ModelState.AddModelError("UserId", "Invalid_user");
                }

                return this.GridOperation(model, request);
            }

            var dbClient = this.clientAdministrationService.Get(model.Id);
            Mapper.Map<ViewModel, Model>(model, dbClient);
            //this.userRoleAdministrationService.Update(dbClient);

            dbClient.Garage = garage;
            dbClient.User = user;

            this.clientAdministrationService.Create(dbClient);
            var addedClient = this.clientAdministrationService.Get(dbClient.Id);
            model.Id = addedClient.Id;
            model.UserName = user.UserName;
            model.GarageName = garage.Name;
            //this.UpdateAuditInfoValues(model, client);

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.clientAdministrationService.Delete(model.Id);
            }

            return this.GridOperation(model, request);
        }

        public JsonResult Garages(string text)
        {
            var contests = this.garageAdministrationService
                 .Read()
                .AsQueryable()
                .ProjectTo<GarageViewModel>();

            if (!string.IsNullOrEmpty(text))
            {
                contests = contests.Where(c => c.Name.ToLower().Contains(text.ToLower()));
            }

            return this.Json(contests, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Users(string text)
        {
            var users = this.userAdministrationService
                .Read()
                .AsQueryable()
                .ProjectTo<UserViewModel>();

            if (!string.IsNullOrEmpty(text))
            {
                users = users.Where(c => c.Name.ToLower().Contains(text.ToLower()));
            }

            return this.Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RenderGrid(int? id)
        {
            return this.PartialView("_Clients", id);
        }

        //[HttpGet]
        //public FileResult ExportToExcelByGarage(DataSourceRequest request, Guid garageId)
        //{
        //    var data = ((IEnumerable<ViewModel>)this.clientAdministrationService.Read()).Where(p => p.GarageId == garageId);
        //    return this.ExportToExcel(request, data);
        //}

        protected JsonResult GridOperation(ViewModel model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

    //    protected void UpdateAuditInfoValues<T>(IAdministrationViewModel<T> viewModel, object databaseModel)
    //where T : class, new()
    //    {
    //        var entry = this.Data.Context.Entry(databaseModel);
    //        viewModel.CreatedOn = (DateTime?)entry.Property(CreatedOnPropertyName).CurrentValue;
    //        viewModel.ModifiedOn = (DateTime?)entry.Property(ModifiedOnPropertyName).CurrentValue;
    //    }
    }
}