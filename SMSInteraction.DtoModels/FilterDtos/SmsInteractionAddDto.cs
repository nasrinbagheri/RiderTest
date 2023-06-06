using SMSInteraction.Enums;

namespace SMSInteraction.DtoModels.FilterDtos;

public class SmsInteractionAddDto
{
    public InteractionType InteractionType { get;  set; }
    public string Title { get;  set; }
}