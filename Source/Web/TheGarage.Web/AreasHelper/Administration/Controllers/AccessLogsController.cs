namespace TheGarage.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using Data;
    using Web.Controllers.Base;

    using ViewModelType = OJS.Web.Areas.Administration.ViewModels.AccessLogs.AccessLogGridViewModel;

    public class AccessLogsController : KendoGridAdministrationController
    {
        public AccessLogsController(TheGarageData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        public override IEnumerable GetData()
        {
            return this.Data.AccessLogs
                .All()
                .Select(ViewModelType.ViewModel);
        }

        public override object GetById(object id)
        {
            return this.Data.AccessLogs.GetById((int)id);
        }
    }
}