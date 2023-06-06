namespace SMSInteraction.DtoModels.FilterDtos;

public class AnswerEditDto
{
    public string Code { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }
    public bool? IsCorrect { get; set; }
    public bool Enabled { get; set; }
}