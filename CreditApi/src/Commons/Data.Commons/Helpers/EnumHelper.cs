using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Commons.Helpers;

/// <summary>
/// 
/// </summary>
public class EnumHelper
{
    /// <summary>
    /// 获取属性字段
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetDescription(object value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name != null)
        {
            var field = type.GetField(name);
            if (field != null)
            {
                var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr == null)
                    return name;
                else
                    return attr.Description;
            }
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DisplayAttribute GetDisplay(object value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name != null)
        {
            var field = type.GetField(name);
            if (field != null)
            {
                var attr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                if (attr == null)
                    return new DisplayAttribute { };
                else
                    return attr;
            }
        }
        return new DisplayAttribute { };
    }
}