namespace SMSInteraction.BlazorApp.Models;

public class ResultViewModel
{
    public bool Successful { get; set; }
}
public class ResultViewModel< T> : ResultViewModel where T : class
{
    public T? Result { get; set; }
}