namespace TheGarage.Web.Areas.Administration.ViewModels.Clients
{
    using System;

    using AutoMapper;
    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;
    using TheGarage.Web.Areas.Administration.ViewModels.Common;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ClientAdministrationViewModel : AdministrationViewModel, IMapFrom<Client>, IMapTo<Client>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public bool IsApproved { get; set; }

        [UIHint("GaragesComboBox")]
        public Guid GarageId { get; set; }

        [UIHint("UsersComboBox")]
        public string UserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string GarageName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Client, ClientAdministrationViewModel>()
              .ForMember(m => m.GarageName, opt => opt.MapFrom(u => u.Garage.Name))
              .ForMember(m => m.GarageId, opt => opt.MapFrom(u => u.Garage.Id))
              .ForMember(m => m.UserId, opt => opt.MapFrom(u => u.User.Id))
              .ForMember(m => m.UserName, opt => opt.MapFrom(u => u.User.UserName));
        }
    }
}