namespace SMSInteraction.Domain;

public class UserAnswer
{
    public UserAnswer(long id, string mobileNo, long smsInteractionId, long answerId)
    {
        Id = id;
        MobileNo = mobileNo;
        SmsInteractionId = smsInteractionId;
        AnswerId = answerId;
        CreationUtcDatetime = DateTime.UtcNow;
    }

    public long Id { get; private set; }
    public string MobileNo { get; private set; }
    public DateTime CreationUtcDatetime { get; private set; }
    public long SmsInteractionId { get; private set; }
    public SmsInteraction SmsInteraction { get; set; }
    public long AnswerId { get; private set; }
    public Answer Answer { get; set; }
    public long? LotteryId { get; private set; }
    public Lottery? Lottery { get; set; }

    public void SetWinnerIn(long lotteryId)
    {
        LotteryId = lotteryId;
    }
}