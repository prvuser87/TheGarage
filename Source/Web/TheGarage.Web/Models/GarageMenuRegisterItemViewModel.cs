namespace TheGarage.Web.Models
{
    using System;

    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;

    public class GarageMenuRegisterItemViewModel : IMapFrom<Garage>, IMapTo<Garage>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}