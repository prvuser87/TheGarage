using AutoMapper.SelfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGarage.Common.Extensions;
using TheGarage.Data.Models;

namespace TheGarage.Web.Models
{
    public class GarageMenuItemViewModel : IMapFrom<Garage>, IMapTo<Garage>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameUrl => this.Name.ToUrl();
    }
}