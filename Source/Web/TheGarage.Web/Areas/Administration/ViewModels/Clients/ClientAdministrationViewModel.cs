namespace TheGarage.Web.Areas.Administration.ViewModels.Clients
{
    using System;

    using TheGarage.Data.Models;
    using AutoMapper.SelfConfig;
    using TheGarage.Web.Areas.Administration.ViewModels.Common;
    using AutoMapper;

    public class ClientAdministrationViewModel : AdministrationViewModel, IMapFrom<Client>, IMapTo<Client>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public bool IsApproved { get; set; }

        public Guid GarageId { get; set; }

        public string UserId { get; set; }

        public Guid PromotionId { get; set; }

        public string PromotionName { get; set; }

        public string UserName { get; set; }

        public string GarageName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Client, ClientAdministrationViewModel>()
              .ForMember(m => m.GarageName, opt => opt.MapFrom(u => u.Garage.Name))
              .ForMember(m => m.PromotionName, opt => opt.MapFrom(u => u.Promotion.Name))
              .ForMember(m => m.UserName, opt => opt.MapFrom(u => u.User.UserName));
        }
    }
}