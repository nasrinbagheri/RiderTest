namespace SMSInteraction.Common.Exceptions;

public class LotteryWinnerCountException : CustomException
{
    public LotteryWinnerCountException(Exception? extraData = null) :
        base(ExceptionConstant.LotteryWinnerCountExceptionCode, "winner counts can not be zero", extraData)
    {
    }
}