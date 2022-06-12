namespace Data.Commons.Runtime;

/// <summary>
///  异常信息处理
/// </summary>
public class MyException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    public MyException()
    {
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public MyException(string message) : base(message)
    {
        ErrorMessage = message;
    }
    
    /// <summary>
    ///  异常信息
    /// </summary>
    public string ErrorMessage { get; private set; }
}

/// <summary>
///   登录异常信息处理
/// </summary>
public class LoginException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    public LoginException() { }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public LoginException(string message) : base(message)
    {
        ErrorMessage = message;
    }

   
    /// <summary>
    /// 异常信息
    /// </summary>
    public string ErrorMessage { get; private set; }
}
