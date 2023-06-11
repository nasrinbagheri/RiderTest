using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;

namespace SMSInteraction.Repository.Interfaces;

public interface IAnswerRepository : IGenericRepository<Answer>
{
    List<AnswerResultDto> GetAnswersOfInteraction(long interactionId);
    AnswerResultDto? GetAnswer(long answerId);
    void Add(long interactionId, AnswerAddDto dto);
    void EditAnswer(long answerId, AnswerEditDto dto);
}