namespace SMSInteraction.DtoModels.FilterDtos;

public class InteractionUserAnswerFilterDto : BaseListFilterDto
{
    public bool? SendCorrectAnswer { get; set; }
}