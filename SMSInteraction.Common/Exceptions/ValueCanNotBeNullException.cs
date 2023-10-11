namespace SMSInteraction.Common.Exceptions;

public class ValueCanNotBeNullException : CustomException
{
    public ValueCanNotBeNullException(string propertyName, Exception? extraData = null) :
        base(ExceptionConstant.ValueCanNotBeNullExceptionCode, $"{propertyName} value can not be null", extraData)
    {
    }
}