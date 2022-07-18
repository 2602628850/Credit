namespace Credit.SettingServices.Dtos;

public class AlibabaCloudSetting : ISetting
{
    /// <summary>
    /// Bucket Name
    /// </summary>
    public string BucketName { get; set; }
    /// <summary>
    /// Endpoint
    /// </summary>
    public string Endpoint { get; set; }
    /// <summary>
    /// AccessKey Id
    /// </summary>
    public string AccessKeyId { get; set; }
    /// <summary>
    /// AccessKey Secret
    /// </summary>
    public string AccessKeySecret { get; set; }
    /// <summary>
    /// 静态资源访问地址
    /// </summary>
    public string StaticUrl { get; set; }
}