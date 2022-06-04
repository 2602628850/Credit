using Credit.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.UserServices
{
    public interface IUserService
    {
        /// <summary>
        ///  用户新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateUser(UserInput input);
    }
}
