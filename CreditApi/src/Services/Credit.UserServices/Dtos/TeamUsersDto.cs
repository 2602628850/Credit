namespace Credit.UserServices.Dtos;

/// <summary>
///  团队成员DTO
/// </summary>
public class TeamUsersDto
{
    /// <summary>
    ///  团队成员Id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///  团队成员相对层级
    /// </summary>
    public int LevelSort { get; set; }
}