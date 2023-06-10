using SMSInteraction.Enums;

namespace SMSInteraction.Domain;

public class Contest : SmsInteraction
{
    public Contest()
    {
        InteractionType = InteractionType.Contest;
    }

    public Contest(long id, string title) : base(id, title)
    {
        InteractionType = InteractionType.Contest;
    }
}