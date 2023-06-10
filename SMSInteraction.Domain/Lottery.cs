namespace SMSInteraction.Domain;

public class Lottery
{
    public Lottery(long id, long smsInteractionId, int winnerCount)
    {
        Id = id;
        SmsInteractionId = smsInteractionId;
        WinnerCount = winnerCount;
        CreationDateTimeUtc = DateTime.UtcNow;
        Winners = new List<UserAnswer>();
    }

    public long Id { get; private set; }
    public int WinnerCount { get; private set; }
    public DateTime CreationDateTimeUtc { get; private set; }
    public long SmsInteractionId { get; set; }
    public SmsInteraction SmsInteraction { get; set; }
    public IEnumerable<UserAnswer> Winners { get; set; }
}