namespace SMSInteraction.Common.Exceptions;

public static class ExceptionConstant
{
    private static readonly int CommonBaseErrorCode = 100;
    private static readonly int SmsInteractionBaseErrorCode = 200;
    private static readonly int AnswerBaseErrorCode = 300;
    private static readonly int LotteryBaseErrorCode = 400;

    public static readonly int ValueCanNotBeNullExceptionCode = CommonBaseErrorCode + 1;

    public static readonly int DuplicateAnswerExceptionCode = AnswerBaseErrorCode + 1;
    public static readonly int AnswerNotFoundExceptionCode = AnswerBaseErrorCode + 2;

    public static readonly int LotteryWinnerCountExceptionCode = LotteryBaseErrorCode + 1;
    public static readonly int LotteryPossibleWinnerCountExceptionCode = LotteryBaseErrorCode + 2;

    public static readonly int SmsInteractionNotFoundExceptionCode = SmsInteractionBaseErrorCode + 1;
}