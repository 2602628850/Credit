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
    ///  用户基础控制器
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
                throw new LoginException("login expired");

            if (CurrentUser == null)
                throw new LoginException("login expired");
        }
    }

    /// <summary>
    ///  管理员基础控制器
    /// </summary>
    public class BaseAdminController : BaseController
    {
        private readonly ITokenManager _tokenManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenManager"></param>
        public BaseAdminController(ITokenManager tokenManager)
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

        private ITokenAdmin _admin;

        public ITokenAdmin CurrentAdmin {
            get
            {
                if (!string.IsNullOrEmpty(Token))
                    _admin = _tokenManager.DeserializeToken<AdminLoginDto>(Token).Result;
                return _admin;
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
                throw new LoginException("login expired");

            if (CurrentAdmin == null)
                throw new LoginException("login expired");
            if (CurrentAdmin.IsAdmin == 0)
                throw new LoginException("login expired");
        }
    }
}
