using IdGen;
using Microsoft.EntityFrameworkCore;
using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;
using SMSInteraction.Enums;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.Repository.Repositories;

public class SmsInteractionRepository : GenericRepository<SmsInteraction>, ISmsInteractionRepository
{
    public SmsInteractionRepository(SmsInteractionDbContext context, IIdGenerator<long> idGenerator) : base(context,
        idGenerator)
    {
    }

    public void Add(SmsInteractionAddDto dto)
    {
        var id = _idGenerator.CreateId();
        switch (dto.InteractionType)
        {
            case InteractionType.Contest:
                Add(new Contest(id: id, title: dto.Title));
                break;
            case InteractionType.Survey:
                Add(new Survey(id: id, title: dto.Title));
                break;
        }
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

    public SmsInteractionResultDto? Get(long id)
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

    public void Edit(long id, SmsInteractionEditDto dto)
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

    public void SaveLottery(long id, int winnerCount)
    {
        if (winnerCount < 1)
        {
            //todo throw exception
        }

        var now = DateTime.UtcNow;
        var interaction = _context.SmsInteractions.Include(s => s.Answers)
            .FirstOrDefault(s => s.Id == id && s.DisabledUtcDateTime <= now);
        if (interaction == null)
        {
            //todo:throw exception
            return;
        }

        var correctAnswer = interaction.Answers.FirstOrDefault(a => a.IsCorrect == true);

        var users = _context.UserAnswers.Where(ua => ua.SmsInteractionId == interaction.Id).AsQueryable();

        if (interaction.InteractionType == InteractionType.Contest && correctAnswer != null)
        {
            users = users.Where(ua => ua.AnswerId == correctAnswer.Id);
        }

        var userAnswersIds = users.Select(s => s.Id).ToList();

        var winnerIds = userAnswersIds.OrderBy(i => Guid.NewGuid()).Take(winnerCount).ToList();

        if (winnerIds.Count == 0)
        {
            //todo throw exception
        }

        var winners = _context.UserAnswers.Where(ua => winnerIds.Contains(ua.Id))
            .ToList();

        var lotteryId = _idGenerator.CreateId();
        var lottery = new Lottery(lotteryId, interaction.Id, winnerCount);

        _context.Lottaries.Add(lottery);
        interaction.SetLottery(lotteryId);

        foreach (var userAnswer in winners)
        {
            userAnswer.SetWinnerIn(lotteryId);
        }
    }
}