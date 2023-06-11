using IdGen;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.Repository.Repositories;

public class UserAnswerRepository : GenericRepository<UserAnswer>, IUserAnswerRepository
{
    public UserAnswerRepository(SmsInteractionDbContext context, IIdGenerator<long> idGenerator) : base(context,
        idGenerator)
    {
    }

    public void AddUserAnswer(UserAnswerAddDto dto)
    {
        var interaction = _context.SmsInteractions.Where(s => s.Enabled == true)
            .OrderByDescending(s => s.EnabledUtcDateTime).Include(s => s.Answers).FirstOrDefault();

        if (interaction == null)
        {
            //todo:exception
            return;
        }

        var answer = interaction.Answers.FirstOrDefault(a => a.Enabled && a.Code == dto.AnswerCode);
        if (answer == null)
        {
            //todo:exception
            return;
        }

        try
        {
            var id = _idGenerator.CreateId();
            var userAnswer = new UserAnswer(id, dto.MobileNo, interaction.Id, answer.Id);
            _context.UserAnswers.Add(userAnswer);
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException { Number: 2627 or 2601 })
        {
//todo:duplicate
        }
    }

    public BasePaginatedResultDto<InteractionUserAnswerListResultDto> GetUserAnswers(long interactionId,
        InteractionUserAnswerFilterDto dto)
    {
        var userAnswers = _context.UserAnswers.Where(ua => ua.SmsInteractionId == interactionId);

        if (dto.SendCorrectAnswer.HasValue && dto.SendCorrectAnswer.Value)
        {
            var correctAnswer =
                _context.Answers.FirstOrDefault(a =>
                    a.SmsInteractionId == interactionId && a.Enabled == true && a.IsCorrect == true);

            userAnswers = correctAnswer == null
                ? new List<UserAnswer>().AsQueryable()
                : userAnswers.Where(ua => ua.AnswerId == correctAnswer.Id);
        }

        var total = userAnswers.Count();
        var result = userAnswers.OrderByDescending(ua => ua.Id).Skip((dto.PageNo - 1) * dto.PageSize)
            .Include(ua => ua.Answer).Select(ua => new InteractionUserAnswerListResultDto
            {
                Id = ua.Id,
                AnswerCode = ua.Answer.Code,
                MobileNo = ua.MobileNo
            }).ToList();

        return new BasePaginatedResultDto<InteractionUserAnswerListResultDto>(dto.PageNo, dto.PageSize, total, result);
    }

    public UserAnswerStatisticsResultDto GetUserAnswerStatistics(long interactionId)
    {
        var userAnswers = _context.UserAnswers.Where(ua => ua.SmsInteractionId == interactionId).AsNoTracking()
            .AsQueryable();

        var total = userAnswers.Count();
        var group = userAnswers.GroupBy(ua => ua.AnswerId)
            .Select(g => new UserStatisticPerAnswerDto
            {
                AnswerCode = g.FirstOrDefault().Answer.Code,
                Count = g.Count(),
                AnswerDescription = g.FirstOrDefault().Answer.Description
            }).ToList();

        var result = new UserAnswerStatisticsResultDto
        {
            StatisticPerAnswers = group,
            TotalUserAnswer = total
        };
        return result;
    }
}