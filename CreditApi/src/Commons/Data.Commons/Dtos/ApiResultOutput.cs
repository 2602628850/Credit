using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Commons.Dtos
{
    /// <summary>
    ///  Api返回类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResultOutput<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ApiResultOutput : ApiResultOutput<object>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class ApiOutputExt : ApiResultOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; set; }
    }
}
