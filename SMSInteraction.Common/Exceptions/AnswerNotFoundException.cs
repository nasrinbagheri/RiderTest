namespace SMSInteraction.Common.Exceptions;

public class AnswerNotFoundException : CustomException
{
    public AnswerNotFoundException(Exception? extraData = null) : base(ExceptionConstant.AnswerNotFoundExceptionCode,
        "answer not found", extraData)
    {
    }
}