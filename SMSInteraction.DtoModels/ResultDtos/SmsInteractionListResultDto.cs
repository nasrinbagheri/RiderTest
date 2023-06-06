using SMSInteraction.Enums;

namespace SMSInteraction.DtoModels.ResultDtos;

public class SmsInteractionListResultDto
{
    public int Id { get; set; }
    public InteractionType InteractionType { get;  set; }
    public string Title { get;  set; }
    public DateTime CreationUtcDateTime { get;  set; }
    public bool Enabled { get;  set; }
    public DateTime? EnabledUtcDateTime { get;  set; }
    public DateTime? DisabledUtcDateTime { get;  set; }
}