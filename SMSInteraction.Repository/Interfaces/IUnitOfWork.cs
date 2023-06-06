namespace SMSInteraction.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ISmsInteractionRepository SmsInteractionRepository { get; }
    IAnswerRepository AnswerRepository { get; }
    IUserAnswerRepository UserAnswerRepository { get; }
    int Complete();
}