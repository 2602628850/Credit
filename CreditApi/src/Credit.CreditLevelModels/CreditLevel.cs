using Data.Commons.Models;

namespace Credit.CreditLevelModels
{
    public class CreditLevel : BaseModel
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