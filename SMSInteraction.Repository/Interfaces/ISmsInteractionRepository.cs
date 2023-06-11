using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;

namespace SMSInteraction.Repository.Interfaces;

public interface ISmsInteractionRepository : IGenericRepository<SmsInteraction>
{
    public void Add(SmsInteractionAddDto dto);
    public BasePaginatedResultDto<SmsInteractionListResultDto> Get(SmsInteractionListFilterDto filter);
    public SmsInteractionResultDto? Get(long id);
    public void Edit(long id, SmsInteractionEditDto dto);
    public void SaveLottery(long id,int winnerCount);
}