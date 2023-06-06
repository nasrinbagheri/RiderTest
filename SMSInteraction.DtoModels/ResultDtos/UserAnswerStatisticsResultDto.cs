namespace SMSInteraction.DtoModels.ResultDtos;

public class UserAnswerStatisticsResultDto
{
    public UserAnswerStatisticsResultDto()
    {
        StatisticPerAnswers = new List<UserStatisticPerAnswerDto>();
    }

    public int TotalUserAnswer { get; set; }
    public List<UserStatisticPerAnswerDto> StatisticPerAnswers { get; set; }
}