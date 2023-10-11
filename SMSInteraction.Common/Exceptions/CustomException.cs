namespace SMSInteraction.Common.Exceptions;

public class CustomException : Exception
{
    public CustomException(int code, string errorMessage, Exception? extraData = null) : base(errorMessage,
        extraData)
    {
        ErrorCode = code;
        ErrorMessage = errorMessage;
        ExtraData = extraData;
    }

    public int ErrorCode { get; private set; }
    public string ErrorMessage { get; private set; }
    public object? ExtraData { get; private set; }
}