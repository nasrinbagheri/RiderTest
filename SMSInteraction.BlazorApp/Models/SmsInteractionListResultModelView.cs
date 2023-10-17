namespace SMSInteraction.BlazorApp.Models;

public class SmsInteractionListResultModelView
{
    public long Id { get; set; }
    public int InteractionType { get;  set; }
    public string? Title { get;  set; }
    public DateTime CreationUtcDateTime { get;  set; }
    public bool Enabled { get;  set; }
    public DateTime? EnabledUtcDateTime { get;  set; }
    public DateTime? DisabledUtcDateTime { get;  set; }

}