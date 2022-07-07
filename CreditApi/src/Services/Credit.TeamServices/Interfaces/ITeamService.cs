using Credit.TeamServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.TeamServices;

/// <summary>
///  团队方法定义
/// </summary>
public interface ITeamService
{
   #region 团队等级

   /// <summary>
   ///  团队等级添加
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   Task TeamLevelCreate(TeamLevelInput input);

   /// <summary>
   ///  团队等级编辑
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   Task TeamLevelUpdate(TeamLevelInput input);

   /// <summary>
   ///  团队等级删除
   /// </summary>
   /// <param name="levelId"></param>
   /// <param name="deleteUserId"></param>
   /// <returns></returns>
   Task TeamLevelDelete(long levelId,long deleteUserId);

   /// <summary>
   ///  获取团队等级
   /// </summary>
   /// <param name="levelId"></param>
   /// <returns></returns>
   Task<TeamLevelDto> GetTeamLevel(long levelId);

   /// <summary>
   ///  获取所有团队等级
   /// </summary>
   /// <returns></returns>
   Task<List<TeamLevelDto>> GetAllTeamLevels();

   /// <summary>
   ///  获取团队等级列表
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   Task<PagedOutput<TeamLevelDto>> GetTeamLevelPagedList(TeamLevelPagedInput input);

   /// <summary>
   ///  更新用户团队等级
   /// </summary>
   /// <param name="userId"></param>
   /// <returns></returns>
   Task UpdateTeamLevel(long userId = 0);

   #endregion

   #region 团队分润

   /// <summary>
   ///  团队分润层级添加
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   Task TeamProfitCreate(TeamBuyProfitSettingInput input);

   /// <summary>
   ///  团队分润层级编辑
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   Task TeamProfitUpdate(TeamBuyProfitSettingInput input);

   /// <summary>
   ///  团队分润层级删除
   /// </summary>
   /// <param name="profitId"></param>
   /// <param name="deleteUserId"></param>
   /// <returns></returns>
   Task TeamProfitDelete(long profitId,long deleteUserId);

   /// <summary>
   ///  获取团队层级分润
   /// </summary>
   /// <param name="profitId"></param>
   /// <returns></returns>
   Task<TeamBuyProfitSettingDto> GetTeamProfit(long profitId);

   /// <summary>
   ///  获取团队分润层级列表
   /// </summary>
   /// <param name="input"></param>
   /// <returns></returns>
   Task<PagedOutput<TeamBuyProfitSettingDto>> GetTeamProfitPagedList(PagedInput input);

   /// <summary>
   ///  用户团队成员分润
   /// </summary>
   /// <param name="userId"></param>
   /// <param name="amount"></param>
   /// <returns></returns>
   Task UserTeamMemberProfit(long userId,decimal amount);

   #endregion
}