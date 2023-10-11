namespace SMSInteraction.Common.Exceptions;

public class SmsInteractionNotFoundException : CustomException
{
    public SmsInteractionNotFoundException(Exception? extraData = null) :
        base(ExceptionConstant.SmsInteractionNotFoundExceptionCode, "sms-interaction not found", extraData)
    {
    }
}