using FreeSql.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSql.Core
{
    public static class FreesqlBuilder
    {
        public static void FreeSqlInit(this IServiceCollection services,string dbConnection)
        {

            FreesqlStatic.FreeSql = new FreeSqlBuilder()
                  .UseConnectionString(DataType.MySql, dbConnection)
                  .UseAutoSyncStructure(true)
                  .UseNameConvert(NameConvertType.PascalCaseToUnderscoreWithLower)
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