namespace TheGarage.Services.Administration
{
    using System.Collections.Generic;

    using TheGarage.Data;
    using TheGarage.Data.Models;
    using TheGarage.Services.Common.Administration;

    public class GaragesAdministrationService : BaseAdministrationService, IGarageAdministrationService
    {
        public GaragesAdministrationService(ITheGarageData data)
            : base(data)
        {
        }

        public void Create(Garage entity)
        {
            this.Data.Garages.Add(entity);
            this.Data.SaveChanges();
        }

        public void Delete(object id)
        {
            var content = this.Data.Garages.GetById(id);

            this.Data.SaveChanges();
        }

        public Garage Get(object id)
        {
            return this.Data.Garages.GetById(id);
        }

        public IEnumerable<Garage> Read()
        {
            return this.Data.Garages.All();
        }

        public void Update(Garage entity)
        {
            this.Data.Garages.Update(entity);
            this.Data.SaveChanges();
        }
    }
}
