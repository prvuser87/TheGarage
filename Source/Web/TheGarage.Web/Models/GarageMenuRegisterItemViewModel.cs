namespace TheGarage.Web.Models
{
    using System;

    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;
    using AutoMapper;

    public class GarageMenuRegisterItemViewModel : IMapFrom<Garage>, IMapTo<Garage>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CompanyId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Garage, GarageMenuRegisterItemViewModel>()
                .ForMember(m => m.CompanyId, opt => opt.MapFrom(u => u.CompanyId));
        }
    }
}