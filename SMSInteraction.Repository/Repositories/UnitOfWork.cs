using IdGen;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.Repository.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SmsInteractionDbContext _context;

    public UnitOfWork(SmsInteractionDbContext context, IIdGenerator<long> idGenerator)
    {
        _context = context;
        SmsInteractionRepository = new SmsInteractionRepository(_context, idGenerator);
        AnswerRepository = new AnswerRepository(_context, idGenerator);
        UserAnswerRepository = new UserAnswerRepository(_context, idGenerator);
    }

    public ISmsInteractionRepository SmsInteractionRepository { get; }
    public IAnswerRepository AnswerRepository { get; }
    public IUserAnswerRepository UserAnswerRepository { get; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}