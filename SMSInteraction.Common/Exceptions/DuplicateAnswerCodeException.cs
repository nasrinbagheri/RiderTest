namespace SMSInteraction.Common.Exceptions;

public class DuplicateAnswerCodeException : CustomException
{
    public DuplicateAnswerCodeException(Exception? extraData = null)
        : base(ExceptionConstant.DuplicateAnswerExceptionCode, "Answer code is duplicate", extraData)
    {
    }
}