using AutoMapper.SelfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGarage.Data.Models;

namespace TheGarage.Web.Models
{
    public class CityMenuRegisterItemViewModel : IMapFrom<City>, IMapTo<City>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid StateId  { get; set; }
    }
}