using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;

namespace SMSInteraction.Repository.Interfaces;

public interface IAnswerRepository : IGenericRepository<Answer>
{
    List<AnswerResultDto> GetAnswersOfInteraction(int interactionId);
    AnswerResultDto? GetAnswer(int answerId);
    void Add(int interactionId, AnswerAddDto dto);
    void EditAnswer(int answerId, AnswerEditDto dto);
}