namespace SMSInteraction.DtoModels.FilterDtos;

public class BaseListFilterDto
{
    public BaseListFilterDto()
    {
        PageSize = 10;
        PageNo = 1;
    }

    public int PageSize { get; set; }
    public int PageNo { get; set; }
}