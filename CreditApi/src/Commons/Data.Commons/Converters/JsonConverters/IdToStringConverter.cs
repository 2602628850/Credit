using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data.Commons.Converters.JsonConverters;

/// <summary>
/// 历史原因, 需要两个转换器
/// Newtonsoft.Json.JsonConverter 使用
/// </summary>
public class IdToStringConverter : JsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objectType"></param>
    /// <returns></returns>
    public override bool CanConvert(Type objectType)
    {
        return typeof(System.Int64).Equals(objectType);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="objectType"></param>
    /// <param name="existingValue"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JToken jt = JToken.ReadFrom(reader);

        return jt.Value<long>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="serializer"></param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value.ToString());
    }
}