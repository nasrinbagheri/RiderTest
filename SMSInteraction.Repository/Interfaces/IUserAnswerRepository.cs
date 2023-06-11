using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;

namespace SMSInteraction.Repository.Interfaces;

public interface IUserAnswerRepository : IGenericRepository<UserAnswer>
{
    public void AddUserAnswer(UserAnswerAddDto dto);

    public BasePaginatedResultDto<InteractionUserAnswerListResultDto> GetUserAnswers(long interactionId,
        InteractionUserAnswerFilterDto dto);

    public UserAnswerStatisticsResultDto GetUserAnswerStatistics(long interactionId);
}