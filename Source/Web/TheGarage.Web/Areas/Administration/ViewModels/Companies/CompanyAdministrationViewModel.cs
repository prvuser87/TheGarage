namespace TheGarage.Web.Areas.Administration.ViewModels.Companies
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;
    using TheGarage.Web.Areas.Administration.ViewModels.Garages;
    using TheGarage.Web.Areas.Administration.ViewModels.Common;

    public class CompanyAdministrationViewModel : AdministrationViewModel, IMapFrom<Company>, IMapTo<Company>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }

        public string Description { get; set; }

        public IEnumerable<GarageAdministrationViewModel> Garages { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Company, CompanyAdministrationViewModel>()
                .ForMember(m => m.Garages, opt => opt.MapFrom(u => u.Garages));
        }
    }
}