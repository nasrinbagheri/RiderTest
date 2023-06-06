namespace SMSInteraction.AdminWebAPI.ResultModels;

public class ResultModel< T> : ResultModel where T : class
{
    public T? Result { get; set; }

    public  static ResultModel<T> Ok(T result)
    {
        return new ResultModel<T> { Successful = true, Result = result };
    }
}

public class ResultModel
{
    public bool Successful { get; set; }

    public static ResultModel Ok()
    {
        return new ResultModel { Successful = true };
    }
}