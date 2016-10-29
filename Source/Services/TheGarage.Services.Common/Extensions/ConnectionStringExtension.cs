using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TheGarage.Data;

namespace TheGarage.Services.Common.Extensions
{
    public static class ConnectionStringExtension
    {
        public static void ChangeDatabaseTo(this ITheGarageData db, string newDatabaseName)
        {
            var conStr = db.Context.Database.Connection.ConnectionString;
            var pattern = "Initial Catalog *= *([^;]*) *";
            var newConStr = Regex.Replace(conStr, pattern, m =>
            {
                return m.Groups.Count == 2
                    ? string.Format("Initial Catalog={0}", newDatabaseName)
                    : m.ToString();
            });

            db.Context.Database.Connection.ConnectionString = newConStr;
        }
    }
}
