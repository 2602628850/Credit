using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commons.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="anonymousTypeObject"></param>
        /// <returns></returns>
        public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject)
        {
            return JsonConvert.DeserializeAnonymousType(value, anonymousTypeObject);
        }
    }
}
