using System.Text;
using System.Web.WebPages;

namespace Data.Commons.Extensions;

public static class StringExtensions
{
    /// <summary>
    ///  卡号显示
    /// </summary>
    /// <param name="cardNo"></param>
    /// <returns></returns>
    public static string CardNoText(this string cardNo)
    {
        if (cardNo.Length <= 4)
            return cardNo;
        var noText = new StringBuilder();
        for (int i = 0; i < cardNo.Length - 4; i++)
        {
            if (string.IsNullOrEmpty(cardNo[i].ToString()))
                noText.Append(" ");
            else
            {
                noText.Append("*");
            }
        }

        return noText.ToString();
    }
    
    /// <summary>
    /// 合并URL
    /// </summary>
    /// <param name="val"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static string UriCombine(this string val, string append)
    {
        if (val.IsEmpty())
        {
            return append;
        }

        if (append.IsEmpty())
        {
            return val;
        }

        return val.TrimEnd('/') + "/" + append.TrimStart('/');
    }
    
    /// <summary>
    ///  卡号显示
    /// </summary>
    /// <param name="cardNo"></param>
    /// <returns></returns>
    public static string CardNoText1(this string cardNo)
    {
        if (cardNo.Length <= 4)
        { 
            return cardNo; 
        }
        cardNo ="**** **** **** " +cardNo.Substring(cardNo.Length - 4, 4);
        return cardNo;
    }
}