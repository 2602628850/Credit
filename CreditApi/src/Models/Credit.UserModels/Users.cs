using Data.Commons.Models;

namespace Credit.UserModels
{
    /// <summary>
    ///  用户
    /// </summary>
    public class Users : BaseModel
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string CountryName { get; set; } = string.Empty;
        /// <summary>
        ///  账号
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        ///  密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// 邀请码
        /// </summary>
        public string InvCode { get; set; } = string.Empty;

        /// <summary>
        ///  头像
        /// </summary>
        public string HeadImage { get; set; } = string.Empty;

        /// <summary>
        ///  可用余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        ///  冻结资金
        /// </summary>
        public decimal FreezeFunds { get; set; }
        /// <summary>
        ///  积分
        /// </summary>
        public decimal Integral { get; set; }
        /// <summary>
        ///  是否管理员
        /// </summary>
        public int IsAdmin { get; set; }
        /// <summary>
        /// 邀请人
        /// </summary>

        public string ParentId { get; set; }

        /// <summary>
        /// 团队团长Id
        /// </summary>

        public string TeamId { get; set; }
        
    }
}