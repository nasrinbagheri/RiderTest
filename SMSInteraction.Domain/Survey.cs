using SMSInteraction.Enums;

namespace SMSInteraction.Domain;

public class Survey : SmsInteraction
{
    public Survey() : base()
    {
        InteractionType = InteractionType.Survey;
    }

    public Survey(long id, string title) : base(id, title)
    {
        InteractionType = InteractionType.Survey;
    }
}