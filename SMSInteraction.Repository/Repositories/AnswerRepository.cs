using IdGen;
using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.Repository.Repositories;

public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
{
    public AnswerRepository(SmsInteractionDbContext context, IIdGenerator<long> idGenerator) : base(context,
        idGenerator)
    {
    }

    public List<AnswerResultDto> GetAnswersOfInteraction(int interactionId)
    {
        var query = _context.Answers.Where(a => a.SmsInteractionId == interactionId).AsQueryable();

        var result = query.Select(a => new AnswerResultDto
        {
            IsCorrect = a.IsCorrect,
            Description = a.Description,
            Priority = a.Priority,
            Code = a.Code,
            Id = a.Id,
            Enabled = a.Enabled
        }).ToList();

        return result;
    }

    public AnswerResultDto? GetAnswer(int answerId)
    {
        var answer = _context.Answers.FirstOrDefault(a => a.Id == answerId);
        if (answer == null)
            return null;

        return new AnswerResultDto
        {
            IsCorrect = answer.IsCorrect,
            Description = answer.Description,
            Priority = answer.Priority,
            Code = answer.Code,
            Id = answer.Id,
            Enabled = answer.Enabled
        };
    }

    public void Add(int interactionId, AnswerAddDto dto)
    {
        var id = _idGenerator.CreateId();

        Add(new Answer(id: id, code: dto.Code, priority: dto.Priority, isCorrect: dto.IsCorrect,
            description: dto.Description,
            smsInteractionId: interactionId));
    }

    public void EditAnswer(int answerId, AnswerEditDto dto)
    {
        var answer = GetById(answerId);
        if (answer == null)
        {
            return; //todo: exception
        }

        answer.SetCode(dto.Code);
        answer.SetCorrect(dto.IsCorrect);
        answer.SetDescription(dto.Description);
        answer.SetPriority(dto.Priority);
        if (dto.Enabled == answer.Enabled)
        {
            return;
        }

        if (dto.Enabled)
        {
            answer.Enable();
        }
        else
        {
            answer.Disable();
        }
    }
}