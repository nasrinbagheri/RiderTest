using IdGen;
using SMSInteraction.Common.Exceptions;
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

    public List<AnswerResultDto> GetAnswersOfInteraction(long interactionId)
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

    public AnswerResultDto? GetAnswer(long answerId)
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

    public void Add(long interactionId, AnswerAddDto dto)
    {
        var id = _idGenerator.CreateId();

        Add(new Answer(id: id, code: dto.Code, priority: dto.Priority, isCorrect: dto.IsCorrect,
            description: dto.Description,
            smsInteractionId: interactionId));
    }

    public void EditAnswer(long answerId, AnswerEditDto dto)
    {
        var answer = GetById(answerId);
        if (answer == null)
            throw new AnswerNotFoundException();

        var duplicateCodeCount = _context.Answers.Count(a => a.Code == dto.Code && a.Id != answerId);
        if (duplicateCodeCount > 0)
        {
            throw new DuplicateAnswerCodeException();
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