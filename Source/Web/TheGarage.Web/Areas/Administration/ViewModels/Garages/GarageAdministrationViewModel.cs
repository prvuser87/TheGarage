namespace TheGarage.Web.Areas.Administration.ViewModels.Garages
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;
    using TheGarage.Web.Areas.Administration.ViewModels.Clients;
    using TheGarage.Web.Areas.Administration.ViewModels.Common;
    using System.Web.Mvc;

    public class GarageAdministrationViewModel : AdministrationViewModel, IMapFrom<Garage>, IMapTo<Garage>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }

        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime BillingDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime GracePeriod { get; set; }

        [HiddenInput(DisplayValue = false)]
        public float GoogleMapLat { get; set; }

        [HiddenInput(DisplayValue = false)]
        public float GoogleMapLng { get; set; }



        public IEnumerable<ClientAdministrationViewModel> Clients { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Garage, GarageAdministrationViewModel>()
              .ForMember(u => u.Clients, opt => opt.MapFrom(u => u.Clients));
        }
    }
}