namespace SMSInteraction.Domain;

public class Lottary
{
    public Lottary()
    {
        CreationDateTimeUtc = DateTime.UtcNow;
        Winners = new List<UserAnswer>();
    }

    public int Id { get; private set; }
    public int WinnerCount { get; private set; }
    public DateTime CreationDateTimeUtc { get; private set; }
    public int SmsInteractionId { get; set; }
    public SmsInteraction SmsInteraction { get; set; }
    public IEnumerable<UserAnswer> Winners { get; set; }
}