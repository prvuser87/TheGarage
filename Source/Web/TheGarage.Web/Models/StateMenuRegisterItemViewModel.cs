namespace TheGarage.Web.Models
{
    using System;

    using AutoMapper.SelfConfig;

    using TheGarage.Data.Models;
    using AutoMapper;

    public class StateMenuRegisterItemViewModel : IMapFrom<State>, IMapTo<State>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}