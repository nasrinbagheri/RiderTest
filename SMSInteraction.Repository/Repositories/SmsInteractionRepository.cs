using Microsoft.EntityFrameworkCore;
using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.Repository.Repositories;

public class SmsInteractionRepository : GenericRepository<SmsInteraction>, ISmsInteractionRepository
{
    public SmsInteractionRepository(SmsInteractionDbContext context) : base(context)
    {
    }

    public BasePaginatedResultDto<SmsInteractionListResultDto> Get(SmsInteractionListFilterDto filter)
    {
        var query = _context.SmsInteractions.AsQueryable();

        if (filter.Enabled.HasValue)
            query = query.Where(s => s.Enabled == filter.Enabled);

        if (filter.FromCreationDate.HasValue)
            query = query.Where(s => s.CreationUtcDateTime >= filter.FromCreationDate.Value.ToUniversalTime());

        if (filter.ToCreationDate.HasValue)
            query = query.Where(s => s.CreationUtcDateTime <= filter.ToCreationDate.Value.ToUniversalTime());

        var total = query.Count();
        var result = query.OrderBy(s => s.Id).Skip((filter.PageNo - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(s => new SmsInteractionListResultDto
            {
                Enabled = s.Enabled,
                InteractionType = s.InteractionType,
                Id = s.Id,
                CreationUtcDateTime = s.CreationUtcDateTime,
                Title = s.Title,
                DisabledUtcDateTime = s.DisabledUtcDateTime,
                EnabledUtcDateTime = s.EnabledUtcDateTime
            }).ToList();

        return new BasePaginatedResultDto<SmsInteractionListResultDto>(filter.PageNo, filter.PageSize, total, result);
    }

    public SmsInteractionResultDto? Get(int id)
    {
        var smsInteraction = _context.SmsInteractions.Include(s => s.Answers).FirstOrDefault(s => s.Id == id);
        if (smsInteraction == null)
            return null;

        var t = new SmsInteractionResultDto
        {
            EnabledUtcDateTime = smsInteraction.EnabledUtcDateTime,
            InteractionType = smsInteraction.InteractionType,
            Id = smsInteraction.Id,
            CreationUtcDateTime = smsInteraction.CreationUtcDateTime,
            Title = smsInteraction.Title,
            DisabledUtcDateTime = smsInteraction.DisabledUtcDateTime,
            Enabled = smsInteraction.Enabled,
            Answers = smsInteraction.Answers.Select(s => new AnswerResultDto
            {
                IsCorrect = s.IsCorrect,
                Id = s.Id,
                Code = s.Code,
                Description = s.Description,
                Priority = s.Priority,
                Enabled = s.Enabled
            })
        };

        return t;
    }

    public void Edit(int id, SmsInteractionEditDto dto)
    {
        var query = _context.SmsInteractions.FirstOrDefault(s => s.Id == id);
        //if null exception
        if (query == null)
            return;
        query.SetTitle(dto.Title);

        if (dto.Enabled == query.Enabled) return;
        if (dto.Enabled)
        {
            query.Enable();
        }
        else
        {
            query.Disable();
        }
    }
}