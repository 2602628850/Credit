using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credit.CreditLevelServices.Dtos; 
using Data.Commons.Dtos;
namespace Credit.CreditLevelServices.Interfaces
{
    public interface ICreditLevelService
    {
        Task CreditLevelCreate(CreditLevelInput input);
        /// <summary>
        ///  信用等级等级编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreditLevelUpdate(CreditLevelInput input);

        /// <summary>
        ///  信用等级删除
        /// </summary>
        /// <param name="levelId"></param>
        /// <param name="deleteUserId"></param>
        /// <returns></returns>
        Task CreditLevelDelete(long levelId, long deleteUserId);
        /// <summary>
        ///  获取信用等级
        /// </summary>
        /// <param name="levelId"></param>
        /// <returns></returns>
        Task<CreditLevelDto> GetCreditLevel(long levelId);

        /// <summary>
        ///  获取所有信用等级
        /// </summary>
        /// <returns></returns>
        Task<List<CreditLevelDto>> GetAllCreditLevels();

        /// <summary>
        ///  获取信用等级列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedOutput<CreditLevelDto>> GetCreditLevelPagedList(CreditLevelPagedInput input);


    }
}
