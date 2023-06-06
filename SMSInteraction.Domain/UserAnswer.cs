namespace SMSInteraction.Domain;

public class UserAnswer
{
    public UserAnswer(string mobileNo, int smsInteractionId, int answerId)
    {
        MobileNo = mobileNo;
        SmsInteractionId = smsInteractionId;
        AnswerId = answerId;
        CreationUtcDatetime = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public string MobileNo { get; private set; }
    public DateTime CreationUtcDatetime { get; private set; }
    public int SmsInteractionId { get; private set; }
    public SmsInteraction SmsInteraction { get; set; }
    public int AnswerId { get; private set; }
    public Answer Answer { get; set; }
    public int? LottaryId { get;private set; }
    public Lottary? Lottary { get; set; }
}