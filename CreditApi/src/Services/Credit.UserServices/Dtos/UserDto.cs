using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Data.Commons.Helpers;

namespace Credit.UserServices.Dtos
{
    /// <summary>
    ///  用户登录输入
    /// </summary>
    public class UserLoginInput
    {
        /// <summary>
        ///  账号
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        ///  密码
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    ///  用户登录信息
    /// </summary>
    public class UserLoginDto : ITokenUser
    {
        /// <summary>
        ///  用户id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///  账号
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        ///  头像
        /// </summary>
        public string HeadImage { get; set; } = string.Empty;

    }

    /// <summary>
    ///   管理员登录信息
    /// </summary>
    public class AdminLoginDto : UserLoginDto, ITokenAdmin
    {
        /// <summary>
        ///  是否管理员
        /// </summary>
        public int IsAdmin { get; set; }
    }

    /// <summary>
    ///  用户登录输出
    /// </summary>
    public class UserLoginOutput
    {
        /// <summary>
        ///   登录token
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        ///  用户信息
        /// </summary>
        public UserLoginDto User { get; set; } = new UserLoginDto();
        /// <summary>
        /// 登录结果提示
        /// </summary>
        public string Msg { get; set; } = string.Empty;
    }

    /// <summary>
    ///  注册用户输入
    /// </summary>
    public class RegisterUserInput : UserLoginInput
    {
        /// <summary>
        ///  确认密码
        /// </summary>
        public string ConfirmPassword { get; set; } = string.Empty;

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;
        /// <summary>
        /// 国家
        /// </summary>
        public string CountryName { get; set; } = string.Empty;
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// 邀请码
        /// </summary>
        public string InvCode { get; set; } = string.Empty;
        /// <summary>
        ///  是否管理员
        /// </summary>
        public int IsAdmin { get; set; }

    }

    public class UserInput : UserLoginInput
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;
        /// <summary>
        ///  昵称
        /// </summary>
        public string HeadImage { get; set; } = string.Empty;
    }

    /// <summary>
    ///  用户信息
    /// </summary>
    public class UserDto : UserInput
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
        /// 邀请人
        /// </summary>

        public long ParentId { get; set; }

        /// <summary>
        ///  根级用户ID
        /// </summary>
        public long RootParentId { get; set; }

        /// <summary>
        /// 个人团队等级
        /// </summary>
        public long TeamLevel { get; set; }
        /// <summary>
        /// 信用值
        /// </summary>

        public int CreditValue { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>

        public long Level { get; set; }

        /// <summary>
        ///  邀请人数
        /// </summary>
        public int InviteCount { get; set; }
        /// <summary>
        /// 直属下级
        /// </summary>
        public int DirectCount { get; set; }
        /// <summary>
        ///  是否团队人员
        /// </summary>
        public int IsTeamUser { get; set; }


        /// <summary>
        ///  是否管理员
        /// </summary>
        public int IsAdmin { get; set; }
    }

    /// <summary>
    ///  用户信用等级信息
    /// </summary>
    public class UserCreditDto
    {
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;
        /// <summary>
        /// 等级
        /// </summary>
        public long LevelId { get; set; }
        /// <summary>
        ///  信用等级名称
        /// </summary>
        public string LevelName { get; set; } = string.Empty;

        /// <summary>
        ///  等级信用值
        /// </summary>
        public int CreditValue { get; set; }

        /// <summary>
        ///  信用等级
        /// </summary>
        public int LevelSort { get; set; }
        /// <summary>
        ///  查卡次数
        /// </summary>
        public int ChakaNum { get; set; }
        /// <summary>
        ///  收益比例
        /// </summary>
        public decimal Profit { get; set; }
    }
    /// <summary>
    ///  团队人数统计
    /// </summary>
    public class UserTeamDto
    {
        /// <summary>
        ///  直属下级
        /// </summary>
        public int Direct { get; set; }
        /// <summary>
        ///  团队注册人数
        /// </summary>
        public int TeamUser { get; set; }
    }

    /// <summary>
    /// 用户收益统计
    /// </summary>
    public class UserProfitDto : UserInput
    {
        /// <summary>
        /// 查卡收益
        /// </summary>
        public decimal ChaKaProfit { get; set; }
        /// <summary>
        /// 理财收益
        /// </summary>
        public decimal SMEProfit { get; set; }

        /// <summary>
        /// 团队收益
        /// </summary>
        public decimal TeamProfit { get; set; }
    }

    /// <summary>
    ///  修改密码
    /// </summary>
    public class ChangePwdInput
    {
        /// <summary>
        ///  直属下级
        /// </summary>
        public string OldPwd { get; set; }
        /// <summary>
        ///  团队注册人数
        /// </summary>
        public string NewPwd { get; set; }
    }
}
