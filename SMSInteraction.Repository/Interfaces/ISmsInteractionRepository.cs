using SMSInteraction.Domain;
using SMSInteraction.DtoModels.FilterDtos;
using SMSInteraction.DtoModels.ResultDtos;

namespace SMSInteraction.Repository.Interfaces;

public interface ISmsInteractionRepository : IGenericRepository<SmsInteraction>
{
    public BasePaginatedResultDto<SmsInteractionListResultDto> Get(SmsInteractionListFilterDto filter);
    public SmsInteractionResultDto? Get(int id);
    public void Edit(int id, SmsInteractionEditDto dto);
}