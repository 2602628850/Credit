using Aliyun.OSS;
using Credit.SettingServices;
using Credit.SettingServices.Dtos;
using Data.Commons.Extensions;
using Data.Core.Controllers;
using Data.Commons.Helpers;
using Data.Commons.Runtime;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers;

/// <summary>
///  文件上传
/// </summary>
public class UploadController : BaseUserController
{
    private readonly ISettingService _settingService;
    
    /// <summary>
    /// 
    /// </summary>
    public UploadController(ITokenManager tokenManager
        ,ISettingService settingService)
    :base(tokenManager)
    {
        _settingService = settingService;
    }

    /// <summary>
    ///  图片上传
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost]
    [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
    public async Task<object> Image([FromBody]IFormFile file)
    {
        try
        {
            if (file != null)
            {
                var isSaveLocal = false; // 本地是否保存
                var savePath = string.Empty;
                var rootDir = "uploads";
                var saveDate = DateTime.UtcNow.ToString("yyyyMMdd");
                // var saveUser = $"{type}_{CurrentUser.Id}";
                var txt = Path.GetExtension(file.FileName).ToLower();
                var saveFilePath = string.Empty;
                var saveFilename = Guid.NewGuid().ToString("N") + txt;
                var src = string.Empty;
                var img = new string[] {".jpg", ".png", ".jpeg", ".mp4"};
                if (!!!img.Contains(txt))
                    throw new MyException("仅支持JPG、JEPG、PNG、MP4的格式");
                if (file.Length > 50 * 1204 * 1000)
                    throw new MyException("请上传50M以下的文件");

                // savePath = Path.Combine(_hostingEnvironment.WebRootPath, rootDir, Tid, saveUser, saveDate);
                src = $"/{rootDir}/{saveDate}/{saveFilename}";

                var alibabaSetting = await _settingService.GetSetting<AlibabaCloudSetting>();

                var bucketName = alibabaSetting.BucketName; // Config.GetValue("aliyunOss:bucketName");
                var endpoint = alibabaSetting.Endpoint; // Config.GetValue("aliyunOss:endpoint");
                var accessKeyId = alibabaSetting.AccessKeyId; // Config.GetValue("aliyunOss:accessKeyId");
                var accessKeySecret = alibabaSetting.AccessKeySecret; // Config.GetValue("aliyunOss:accessKeySecret");
                var staticUrl = alibabaSetting.StaticUrl;

                // saveFilePath, 文件保存在服务器的位置
                var ossClient = new OssClient(endpoint, accessKeyId, accessKeySecret);
                if (isSaveLocal)
                {
                    var ossResult = ossClient.PutObject(bucketName, src.TrimStart('/'), saveFilePath);
                }
                else
                {
                    var ossResult = ossClient.PutObject(bucketName, src.TrimStart('/'), file.OpenReadStream());
                }

                return new {src = staticUrl.UriCombine(src)};
            }
            else
            {
                throw new MyException("上传文件为空");
            }
        }
        catch (Exception e)
        {
            throw new MyException(e.Message);
        }
    }


    /// <summary>
    /// 上传头像
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
    public async Task<object> HeadImage(IFormFile file)
    {
        try
        {
             if (file != null)
            {
                var isSaveLocal = false; // 本地是否保存
                var savePath = string.Empty;
                var rootDir = "uploads";
                var saveDate = DateTime.UtcNow.ToString("yyyyMMdd");
                var txt = Path.GetExtension(file.FileName).ToLower();
                var saveFilePath = string.Empty;
                var saveFilename = Guid.NewGuid().ToString("N") + txt;
                var src = string.Empty;
                var img = new string[] {".jpg", ".png", ".jpeg", ".mp4"};
                if (!img.Contains(txt))
                    return new { imgUrl = string.Empty,msg = "Only supports JPG, JPEG, PNG, MP4 formats"};
                if (file.Length > 50 * 1204 * 1000)
                {
                    return new { imgUrl = string.Empty,msg = "Please upload files under 50M"};
                }
                // savePath = Path.Combine(_hostingEnvironment.WebRootPath, rootDir, Tid, saveUser, saveDate);
                src = $"/{rootDir}/HeadImage/{CurrentUser.UserId}/{saveDate}/{saveFilename}";

                var alibabaSetting = await _settingService.GetSetting<AlibabaCloudSetting>();

                var bucketName = alibabaSetting.BucketName; // Config.GetValue("aliyunOss:bucketName");
                var endpoint = alibabaSetting.Endpoint; // Config.GetValue("aliyunOss:endpoint");
                var accessKeyId = alibabaSetting.AccessKeyId; // Config.GetValue("aliyunOss:accessKeyId");
                var accessKeySecret = alibabaSetting.AccessKeySecret; // Config.GetValue("aliyunOss:accessKeySecret");
                var staticUrl = alibabaSetting.StaticUrl;

                // saveFilePath, 文件保存在服务器的位置
                var ossClient = new OssClient(endpoint, accessKeyId, accessKeySecret);
                if (isSaveLocal)
                {
                    var ossResult = ossClient.PutObject(bucketName, src.TrimStart('/'), saveFilePath);
                }
                else
                {
                    var ossResult = ossClient.PutObject(bucketName, src.TrimStart('/'), file.OpenReadStream());
                }

                return new {imgUrl = staticUrl.UriCombine(src),msg = "upload success"};
            }
            else
            {
                return new { imgUrl = string.Empty,msg = "file is empty"};
            }
        }
        catch (Exception e)
        {
            return new { imgUrl = string.Empty,msg = e.Message};
        }
    }
}