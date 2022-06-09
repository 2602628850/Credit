using Microsoft.AspNetCore.Http;
namespace Data.Commons.Extensions;

public static class HttpRequestExtensions
{
    /// <summary>
    /// 优先获取某些CDN商家自定义头
    /// X-Forwarded-For 和 X-Real-IP 必须放在最后
    /// </summary>
    private static readonly string[] headersTarget = new[] { "X-Forwarded-For", "X-Real-IP" };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string GetClientIpAddress(this HttpRequest request)
    {
        var ipAddress = request.Headers["X-True-IP"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(ipAddress))
        {
            foreach (var target in headersTarget)
            {
                if (!!!string.IsNullOrWhiteSpace(ipAddress))
                    break;
                ipAddress = request.Headers[target].FirstOrDefault();
            }
        }

        //if (string.IsNullOrWhiteSpace(ipAddress))
        //    ipAddress = request.HttpContext.Connection.RemoteIpAddress.ToString();
        return ipAddress;
    }
}