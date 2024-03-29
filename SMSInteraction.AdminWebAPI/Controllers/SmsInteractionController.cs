using Microsoft.AspNetCore.Mvc;
using SMSInteraction.AdminWebAPI.ResultModels;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.AdminWebAPI.Controllers;

[ApiController]
[Route("sms-interactions")]
public class SmsInteractionController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public SmsInteractionController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ResultModel<BasePaginatedResultDto<SmsInteractionListResultDto>> Get(
        [FromQuery] SmsInteractionListFilterDto filter)
    {
        var result = _unitOfWork.SmsInteractionRepository.Get(filter);

        return ResultModel<BasePaginatedResultDto<SmsInteractionListResultDto>>.Ok(result);
    }

    [HttpPost]
    public ResultModel Add([FromBody] SmsInteractionAddDto model)
    {
        _unitOfWork.SmsInteractionRepository.Add(model);
        _unitOfWork.Complete();
        return ResultModel.Ok();
    }

    [HttpGet("{id}")]
    public ResultModel<SmsInteractionResultDto> Get([FromRoute] long id)
    {
        var result = _unitOfWork.SmsInteractionRepository.Get(id);
        return ResultModel<SmsInteractionResultDto>.Ok(result);
    }

    [HttpPut("{id}")]
    public ResultModel Edit([FromRoute] long id, [FromBody] SmsInteractionEditDto dto)
    {
        _unitOfWork.SmsInteractionRepository.Edit(id, dto);
        _unitOfWork.Complete();
        return ResultModel.Ok();
    }

    [HttpGet("{interactionId}/answers")]
    public ResultModel<List<AnswerResultDto>> GetAnswers(long interactionId)
    {
        var answers = _unitOfWork.AnswerRepository.GetAnswersOfInteraction(interactionId);
        return ResultModel<List<AnswerResultDto>>.Ok(answers);
    }

    [HttpPost("{interactionId}/answers")]
    public ResultModel AddAnswer([FromRoute] long interactionId, [FromBody] AnswerAddDto dto)
    {
        _unitOfWork.AnswerRepository.Add(interactionId, dto);
        _unitOfWork.Complete();
        return ResultModel.Ok();
    }

    [HttpGet("{interactionId}/answers/{answerId}")]
    public ResultModel<AnswerResultDto> GetAnswer([FromRoute] long answerId)
    {
        var answer = _unitOfWork.AnswerRepository.GetAnswer(answerId);
        return ResultModel<AnswerResultDto>.Ok(answer);
    }

    [HttpPost("user-answers")]
    public ResultModel AddUserAnswer([FromBody] UserAnswerAddDto dto)
    {
        _unitOfWork.UserAnswerRepository.AddUserAnswer(dto);
        _unitOfWork.Complete();
        return ResultModel.Ok();
    }

    [HttpGet("{interactionId}/user-answers")]
    public ResultModel<BasePaginatedResultDto<InteractionUserAnswerListResultDto>> GetInteractionUserAnswers(
        [FromRoute] long interactionId,
        [FromQuery] InteractionUserAnswerFilterDto dto)
    {
        var result = _unitOfWork.UserAnswerRepository.GetUserAnswers(interactionId, dto);
        return ResultModel<BasePaginatedResultDto<InteractionUserAnswerListResultDto>>.Ok(result);
    }

    [HttpGet("{interactionId}/user-answers/statistics")]
    public ResultModel<UserAnswerStatisticsResultDto> GetUserAnswerStatistics([FromRoute] long interactionId)
    {
        var result = _unitOfWork.UserAnswerRepository.GetUserAnswerStatistics(interactionId);
        return ResultModel<UserAnswerStatisticsResultDto>.Ok(result);
    }

    [HttpPost("{interactionId}/lottery")]
    public ResultModel AddLottery([FromRoute] long interactionId, [FromBody] LotteryAddDto dto)
    {
        _unitOfWork.SmsInteractionRepository.SaveLottery(interactionId, dto.WinnerCount);
        _unitOfWork.Complete();
        return ResultModel.Ok();
    }
}