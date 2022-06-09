using FreeSql.Internal;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace FreeSql.Core
{
    public static class FreesqlBuilder
    {
        public static void FreeSqlInit(this IServiceCollection services,string connectionString)
        {

            FreesqlStatic.FreeSql = new FreeSqlBuilder()
                  .UseAutoSyncStructure(true)
                  .UseNameConvert(NameConvertType.PascalCaseToUnderscoreWithLower)
                  .UseConnectionFactory(DataType.MySql, () =>
                  {
                      var conn = new MySqlConnection(connectionString);
                      return conn;
                  })
                  .Build();
            FreesqlStatic.FreeSql.Aop.ConfigEntityProperty += (s, e) =>
            {
                if (e.Property.PropertyType.IsEnum)
                {
                    e.ModifyResult.MapType = typeof(int);
                }

                if (e.Property.PropertyType == typeof(decimal) || e.Property.PropertyType == typeof(decimal?))
                {
                    e.ModifyResult.Precision = 18;
                    e.ModifyResult.Scale = 2;
                }
            };

            FreesqlStatic.FreeSql.UseJsonMap();

            services.AddSingleton<IFreeSql>(FreesqlStatic.FreeSql);
        }
    }
}