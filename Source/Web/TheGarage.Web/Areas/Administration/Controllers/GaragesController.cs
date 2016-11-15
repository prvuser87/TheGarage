namespace TheGarage.Web.Areas.Administration.Controllers
{
    using Newtonsoft.Json;
    using System.Linq;
    using System.Web.Mvc;
    
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using TheGarage.Common;
    using TheGarage.Services.Common.Administration;

    using Model = TheGarage.Data.Models.Garage;
    using ViewModel = TheGarage.Web.Areas.Administration.ViewModels.Clients.GarageViewModel;

    public class GaragesController : AdminController
    {
        private readonly IGarageAdministrationService garageAdministrationService;

        public GaragesController(IGarageAdministrationService garageAdministrationService)
        {
            this.garageAdministrationService = garageAdministrationService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var data = this.garageAdministrationService
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
                var dbmodel = Mapper.Map<Model>(model);

                this.garageAdministrationService.Create(dbmodel);
            }


            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {


            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.garageAdministrationService.Get(model.Id);
                Mapper.Map<ViewModel, Model>(model, dbModel);
                this.garageAdministrationService.Update(dbModel);
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.garageAdministrationService.Delete(model.Id);
            }

            return this.GridOperation(model, request);
        }

        protected JsonResult GridOperation(ViewModel model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}