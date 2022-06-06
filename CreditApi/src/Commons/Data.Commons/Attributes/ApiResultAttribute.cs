using Data.Commons.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Data.Commons.Attributes;

public class ApiResultAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
        if (context.Result is ObjectResult || context.Result is EmptyResult || context.Result == null)
        {
            if (context.Exception == null)
            {
                //返回模型
                var result = new ApiResultOutput();
                result.Success = true;
                result.Status = 200;
                if (context.Result == null)
                {
                    context.Result = new ObjectResult(result);
                }
                else
                {
                    //取得返回数据
                    var objResult = context.Result as ObjectResult;
                    result.Data = objResult?.Value;
                    context.Result = new ObjectResult(result);
                }
            }
        }
    }
}