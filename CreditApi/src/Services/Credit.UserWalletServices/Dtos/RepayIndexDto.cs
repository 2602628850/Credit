using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.UserWalletServices.Dtos;
    public class RepayIndexDto
    {
    /// <summary>
    /// 剩余还款次数
    /// </summary>
    public int RemainingTime { get; set; } = 0;
    /// <summary>
    /// 已还款次数
    /// </summary>
    public int RepaymentTimes { get; set; } = 0;
    /// <summary>
    /// 还款收益
    /// </summary>
    public decimal RepaymentIncome { get; set; } = 0;
    /// <summary>
    /// 账户余额
    /// </summary>
    public decimal Balance { get; set; }
    }
