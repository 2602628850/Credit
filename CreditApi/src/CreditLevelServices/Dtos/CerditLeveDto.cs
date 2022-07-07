using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.CreditLevelServices.Dtos
{
    public class CerditLevelDto : CerditLevelInput
    {
        /// <summary>
        ///  添加时间
        /// </summary>
        public long CreateAt { get; set; }
    }

    /// <summary>
    ///  信用等级输入
    /// </summary>
    public class CerditLevelInput
    {

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
}
