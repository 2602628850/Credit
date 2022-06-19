using System.Text;

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
}