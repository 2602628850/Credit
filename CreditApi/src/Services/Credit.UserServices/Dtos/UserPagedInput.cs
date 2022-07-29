using Data.Commons.Dtos;

namespace Credit.UserServices.Dtos;

/// <summary>
///  管理员分页输入
/// </summary>
public class UserPagedInput : PagedInput
{
    /// <summary>
    ///  管理员名称
    /// </summary>
    public string UserName { get; set; } = string.Empty;
}