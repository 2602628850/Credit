using FreeSql.DataAnnotations;

namespace Credit.UserModels
{
    [Table(Name = "users")]
    public class Users
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  账号
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///  密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///  昵称
        /// </summary>
        public string Nickname { get; set; }
    }
}