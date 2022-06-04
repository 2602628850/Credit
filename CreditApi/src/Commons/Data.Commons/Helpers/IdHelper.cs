using Snowflake.Core;

namespace Data.Commons.Helpers
{
    /// <summary>
    /// Id生成器
    /// </summary>
    public class IdHelper
    {
        static IdWorker worker = null;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="datacenterId"></param>
        public static void Init(long workerId, long datacenterId)
        {
            worker = new IdWorker(workerId, datacenterId);
        }

        /// <summary>
        /// 获取id
        /// </summary>
        /// <returns></returns>
        public static long GetId()
        {
            long id = worker.NextId();
            return id;
        }
    }
}
