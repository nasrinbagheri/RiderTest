namespace SMSInteraction.DtoModels.ResultDtos;

public class BasePaginatedResultDto<T> where T : class
{
    public BasePaginatedResultDto(int pageNo, int pageSize, int totalNo, List<T> list)
    {
        PageNo = pageNo;
        PageSize = pageSize;
        TotalNo = totalNo;
        List = list;
    }

    public int TotalNo { get; set; }
    public int PageNo { get; set; }
    public int PageSize { get; set; }
    public List<T> List { get; set; }
}