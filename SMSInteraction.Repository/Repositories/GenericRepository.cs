using System.Linq.Expressions;
using IdGen;
using SMSInteraction.Repository.Interfaces;

namespace SMSInteraction.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly SmsInteractionDbContext _context;
    protected readonly IIdGenerator<long> _idGenerator;

    public GenericRepository(SmsInteractionDbContext context, IIdGenerator<long> idGenerator)
    {
        _context = context;
        _idGenerator = idGenerator;
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public T? GetById(long id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}