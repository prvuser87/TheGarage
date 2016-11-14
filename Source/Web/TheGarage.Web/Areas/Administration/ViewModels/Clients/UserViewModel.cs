namespace TheGarage.Web.Areas.Administration.ViewModels.Clients
{
    using AutoMapper;
    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;
    using TheGarage.Web.Areas.Administration.ViewModels.Common;

    public class UserViewModel : AdministrationViewModel, IMapFrom<User>, IMapTo<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
              .ForMember(m => m.Name, opt => opt.MapFrom(u => u.UserName));
        }
    }
}