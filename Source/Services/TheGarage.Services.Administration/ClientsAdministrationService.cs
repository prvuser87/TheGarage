namespace TheGarage.Services.Administration
{
    using System.Collections.Generic;

    using TheGarage.Data;
    using TheGarage.Data.Models;
    using TheGarage.Services.Common.Administration;

    public class ClientsAdministrationService : BaseAdministrationService, IClientAdministrationService
    {
        public ClientsAdministrationService(ITheGarageData data)
            : base(data)
        {
        }

        public void Create(Client entity)
        {
            this.Data.Clients.Add(entity);
            this.Data.SaveChanges();
        }

        public void Delete(object id)
        {
            var content = this.Data.Clients.GetById(id);

            this.Data.SaveChanges();
        }

        public Client Get(object id)
        {
            return this.Data.Clients.GetById(id);
        }

        public IEnumerable<Client> Read()
        {
            return this.Data.Clients.All();
        }

        public void Update(Client entity)
        {
            this.Data.Clients.Update(entity);
            this.Data.SaveChanges();
        }
    }
}