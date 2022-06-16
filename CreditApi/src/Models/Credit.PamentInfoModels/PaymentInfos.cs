using Data.Commons.Models;

namespace Credit.PamentInfoModels
{
    /// <summary>
    ///  充值通道
    /// </summary>
    public class PaymentInfos : BaseModel
    {
        /// <summary>
        ///  接口名称
        /// </summary>
        public string PaymentName { get; set; } = string.Empty;

        /// <summary>
        ///  显示名称
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        ///  请求地址
        /// </summary>
        public string RequestUrl { get; set; } = string.Empty;

        /// <summary>
        ///  商户号
        /// </summary>
        public string MerchantNo { get; set; } = string.Empty;

        /// <summary>
        ///  私钥
        /// </summary>
        public string PrivateKey { get; set; } = string.Empty;

        /// <summary>
        ///  公钥
        /// </summary>
        public string PublicKey { get; set; } = string.Empty;

        /// <summary>
        ///  最低金额限制
        /// </summary>
        public decimal MinAmountLimit { get; set; }

        /// <summary>
        ///  最高金额限制
        /// </summary>
        public decimal MaxAmountLimit { get; set; }
        
        /// <summary>
        ///  开启时间
        /// </summary>
        public long StartTime { get; set; }

        /// <summary>
        ///  关闭时间
        /// </summary>
        public long EndTime { get; set; }

        /// <summary>
        ///  是否启动
        /// </summary>
        public int IsEnable { get; set; }
    }
}

