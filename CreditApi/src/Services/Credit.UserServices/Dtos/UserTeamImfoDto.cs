using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.UserServices.Dtos;

/// <summary>
/// 用户团队收益
/// </summary>
public class UserTeamImfoDto
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public long UserId { get; set; }
    /// <summary>
    /// 团队注册人数
    /// </summary>
    public int TeamRegister { get; set; }
    /// <summary>
    /// 团队正式人数
    /// </summary>
    public int TeamMember { get; set; }
    /// <summary>
    /// 团队总还款
    /// </summary>
    public decimal TeamRepayment { get; set; }
    /// <summary>
    /// 预计还款收益
    /// </summary>
    public decimal TeamEstimateRepaymentRevenue { get; set; }
    /// <summary>
    /// 预计理财购买收益
    /// </summary>
    public decimal TeamEstimatePurchaseRevenue { get; set; }
    /// <summary>
    /// 团队总收益
    /// </summary>
    public decimal TotalRevenue { get; set; }




}
