namespace TheGarage.Services.Common.Extensions
{
    using System.Text.RegularExpressions;
    using TheGarage.Data;

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
