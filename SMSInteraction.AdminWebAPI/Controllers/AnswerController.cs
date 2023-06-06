using Microsoft.AspNetCore.Mvc;
using SMSInteraction.AdminWebAPI.ResultModels;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.AdminWebAPI.Controllers;

[ApiController]
[Route("answers")]
public class AnswerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AnswerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{answerId}")]
    public ResultModel<AnswerResultDto> GetAnswer([FromRoute] int answerId)
    {
        var answer = _unitOfWork.AnswerRepository.GetAnswer(answerId);
        return ResultModel<AnswerResultDto>.Ok(answer);
    }

    [HttpPut("{answerId}")]
    public ResultModel Edit([FromRoute] int answerId, [FromBody] AnswerEditDto dto)
    {
        _unitOfWork.AnswerRepository.EditAnswer(answerId, dto);
        _unitOfWork.Complete();
        return ResultModel.Ok();
    }
}