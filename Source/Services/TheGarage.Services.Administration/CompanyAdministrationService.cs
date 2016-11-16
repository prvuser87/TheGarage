namespace TheGarage.Services.Administration
{
    using System.Collections.Generic;

    using TheGarage.Data;
    using TheGarage.Data.Models;
    using TheGarage.Services.Common.Administration;

    public class CompanyAdministrationService : BaseAdministrationService, ICompanyAdministrationService
    {
        public CompanyAdministrationService(ITheGarageData data)
            : base(data)
        {
        }

        public void Create(Company entity)
        {
            this.Data.Companies.Add(entity);
            this.Data.SaveChanges();
        }

        public void Delete(object id)
        {
            var content = this.Data.Companies.GetById(id);

            this.Data.SaveChanges();
        }

        public Company Get(object id)
        {
            return this.Data.Companies.GetById(id);
        }

        public IEnumerable<Company> Read()
        {
            return this.Data.Companies.All();
        }

        public void Update(Company entity)
        {
            this.Data.Companies.Update(entity);
            this.Data.SaveChanges();
        }
    }
}
