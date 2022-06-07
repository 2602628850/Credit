using Mapster;

namespace Data.Commons.Extensions
{
    /// <summary>
    ///  object
    /// </summary>
    public static class ObjectMapExtensions
    {
        /// <summary>
        /// 实体转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null)
                return default(T);

            return obj.Adapt<T>();
        }

        /// <summary>
        /// List转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T> MapToList<T>(this object obj)
        {
            if (obj is IEnumerable<object>)
            {
                var output = new List<T>();
                foreach (var d in obj as IEnumerable<object>)
                {
                    output.Add(d.MapTo<T>());
                }
                return output;
            }
            return new List<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ObjectToDictionary(this object obj)
        {
            var properties = obj.GetType().GetProperties();
            var dic = new Dictionary<string, dynamic>();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                var value = info.GetValue(obj, null);
                dic.Add(info.Name, value);
            }

            return dic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="ignoreName"></param>
        /// <param name="ignoreNull"></param>
        /// <returns></returns>
        public static string GetHttpQuery(this IDictionary<string, object> dic, string[] ignoreName = null, bool ignoreNull = true)
        {
            if (dic == null || dic.Count == 0)
                return ""; // 不要返回null

            var str = string.Empty;
            foreach (var item in dic)
            {
                if (ignoreNull == true && string.IsNullOrWhiteSpace(item.Value?.ToString()))
                    continue;

                if (ignoreName?.Contains(item.Key) ?? false)
                    continue;

                str += $"{item.Key}={item.Value}&";
            }
            return str.TrimEnd('&');
        }
    }
}
