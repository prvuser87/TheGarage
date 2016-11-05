namespace TheGarage.Services.Administration
{
    using System.Collections.Generic;

    using TheGarage.Data;
    using TheGarage.Data.Models;
    using TheGarage.Services.Common.Administration;

    public abstract class BaseAdministrationService
    {
        private readonly ITheGarageData data;

        public BaseAdministrationService(ITheGarageData data)
        {
            this.data = data;
        }

        protected ITheGarageData Data
        {
            get { return this.data; }
        }
    }
}
