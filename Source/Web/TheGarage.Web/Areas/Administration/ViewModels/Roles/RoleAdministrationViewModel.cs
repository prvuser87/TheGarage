namespace TheGarage.Web.Areas.Administration.ViewModels.Roles
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity.EntityFramework;
    using AutoMapper.SelfConfig;
    using Data.Models;
    using AutoMapper;
    using Common;

    public class RoleAdministrationViewModel : AdministrationViewModel, IMapFrom<IdentityRole>, IMapTo<IdentityRole>, IHaveCustomMappings
    {
        public string RoleId { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<IdentityRole, RoleAdministrationViewModel>()
              .ForMember(m => m.RoleId, opt => opt.MapFrom(u => u.Id))
              .ForMember(m => m.Name, opt => opt.MapFrom(u => u.Name));
        }
    }
}