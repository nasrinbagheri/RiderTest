namespace SMSInteraction.Domain;

public class Answer
{
    public Answer(long id, string code, int priority, string description, bool? isCorrect, long smsInteractionId)
    {
        Id = id;
        Code = code;
        Priority = priority;
        Description = description;
        IsCorrect = isCorrect;
        SmsInteractionId = smsInteractionId;
        Enabled = true;
    }

    public long Id { get; }
    public string Code { get; private set; }
    public int Priority { get; private set; }
    public string Description { get; private set; }
    public bool? IsCorrect { get; private set; }
    public bool Enabled { get; private set; }
    public long SmsInteractionId { get; }
    public SmsInteraction SmsInteraction { get; }
    public IEnumerable<UserAnswer> UserAnswers { get; set; }

    public void SetCode(string code)
    {
        //todo: add validation not redundant code
        Code = code;
    }

    public void SetPriority(int priority)
    {
        Priority = priority;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetCorrect(bool? correct)
    {
        IsCorrect = correct;
    }

    public void Enable()
    {
        Enabled = true;
    }

    public void Disable()
    {
        Enabled = false;
    }
}