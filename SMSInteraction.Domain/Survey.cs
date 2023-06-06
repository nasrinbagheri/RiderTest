using SMSInteraction.Enums;

namespace SMSInteraction.Domain;

public class Survey : SmsInteraction
{
    public Survey() : base()
    {
        InteractionType = InteractionType.Survey;
    }

    public Survey(string title) : base(title)
    {
        InteractionType = InteractionType.Survey;
    }
}