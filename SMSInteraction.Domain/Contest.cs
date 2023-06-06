using SMSInteraction.Enums;

namespace SMSInteraction.Domain;

public class Contest : SmsInteraction
{
    public Contest()
    {
        InteractionType = InteractionType.Contest;
    }

    public Contest(string title) : base(title)
    {
        InteractionType = InteractionType.Contest;
    }
}