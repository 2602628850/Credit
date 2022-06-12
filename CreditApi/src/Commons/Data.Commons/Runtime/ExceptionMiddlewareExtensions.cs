using Data.Commons.Dtos;
using Data.Commons.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Data.Commons.Runtime;

public static class ExceptionMiddlewareExtensions
{
    public static void UseAllRoadApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var thatCode = context.Response.StatusCode;
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    if (contextFeature.Error is LoginException)
                    {
                        await context.Response.WriteAsync(JsonHelper.SerializeObject(new ApiResultOutput
                        {
                            Status = 401,
                            Success = false,
                            Message = contextFeature.Error.Message
                        }));
                    }
                    else
                    {
                        var errMsg = contextFeature.Error.Message;
                        if (errMsg?.IndexOf("主库") > -1 || errMsg?.IndexOf("状态不可用") > -1)
                            errMsg = "Please try refreshing the interface";

                        await context.Response.WriteAsync(JsonHelper.SerializeObject(new ApiResultOutput
                        {
                            Status = thatCode,
                            Success = false,
                            Message = errMsg
                        }));
                    }
                }
            });
        });
    }
}