namespace SMSInteraction.DtoModels.FilterDtos;

public class SmsInteractionListFilterDto : BaseListFilterDto
{
    public DateTime? FromCreationDate { get; set; }
    public DateTime? ToCreationDate { get; set; }
    public bool? Enabled { get; set; }
}