using FreeSql.DataAnnotations;
namespace Data.Commons.Models
{
    public class BaseMdel
    {
        /// <summary>
        ///  主键Id
        /// </summary>
        [Column(IsPrimary = true)]
        public long Id { get; set; }

        /// <summary>
        ///  创建时间
        /// </summary>
        public long CreateAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        ///  更新时间
        /// </summary>
        public long UpdateAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        ///  删除 0 未删除  1 已删除
        /// </summary>
        public int IsDeleted { get; set; } = 0;

        /// <summary>
        ///  删除用户Id
        /// </summary>
        public long DeleteUserId { get; set; }
    }
}
