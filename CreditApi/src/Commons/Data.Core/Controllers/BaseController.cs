using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Credit.UserServices.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Data.Core.Controllers
{
    /// <summary>
    ///  基础控制器
    /// </summary>
    [Route("v1/[controller]/[action]")]
    public class BaseController : Controller
    {
        public string IpAddress => Request.GetClientIpAddress();
    }

    /// <summary>
    ///  用户控制器
    /// </summary>
    public class BaseUserController : BaseController
    {
        private readonly ITokenManager _tokenManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenManager"></param>
        public BaseUserController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        private string _token;
        private static object _lock = new object();

        private string GetToken()
        {
            lock (_lock)
            {
                if (string.IsNullOrEmpty(_token))
                    _token = Request.Headers["Token"].FirstOrDefault();
                return _token;
            }
        }

        public string Token => GetToken();

        private ITokenUser _user;

        public ITokenUser CurrentUser {
            get
            {
                if (!string.IsNullOrEmpty(Token))
                    _user = _tokenManager.DeserializeToken<UserLoginDto>(Token).Result;
                return _user;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="MyException"></exception>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (string.IsNullOrWhiteSpace(Token))
                throw new MyException("login expired");

            if (CurrentUser == null)
                throw new MyException("login expired");
        }
    }
}
