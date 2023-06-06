namespace SMSInteraction.DtoModels.FilterDtos;

public class AnswerAddDto
{
    public string Code { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }
    public bool? IsCorrect { get; set; }
}