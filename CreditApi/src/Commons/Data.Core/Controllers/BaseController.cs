using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Data.Core.Controllers
{
    /// <summary>
    ///  基础控制器
    /// </summary>
    [Route("v1/[controller]/[action]")]
    public class BaseController : Controller
    {
    }

    public class BaseUserController : BaseController
    { 
    
    }
}
