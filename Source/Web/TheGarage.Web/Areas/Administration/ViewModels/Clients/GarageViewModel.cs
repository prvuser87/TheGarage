namespace TheGarage.Web.Areas.Administration.ViewModels.Clients
{
    using System;

    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;
    using TheGarage.Web.Areas.Administration.ViewModels.Common;
    
    public class GarageViewModel : AdministrationViewModel, IMapFrom<Garage>, IMapTo<Garage>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}