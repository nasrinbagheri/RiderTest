using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;

namespace SMSInteraction.Repository.Interfaces;

public interface IUserAnswerRepository : IGenericRepository<UserAnswer>
{
    public void AddUserAnswer(UserAnswerAddDto dto);

    public BasePaginatedResultDto<InteractionUserAnswerListResultDto> GetUserAnswers(int interactionId,
        InteractionUserAnswerFilterDto dto);

    public UserAnswerStatisticsResultDto GetUserAnswerStatistics(int interactionId);
}