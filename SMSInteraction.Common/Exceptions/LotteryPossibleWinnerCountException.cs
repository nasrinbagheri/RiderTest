namespace SMSInteraction.Common.Exceptions;

public class LotteryPossibleWinnerCountException : CustomException
{
    public LotteryPossibleWinnerCountException(Exception? extraData = null) :
        base(ExceptionConstant.LotteryPossibleWinnerCountExceptionCode,"there isn't any winner in this sms-interaction", extraData)
    {
    }
}