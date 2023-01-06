using DemoApp.CommandStack.Domain.Common;

namespace DemoApp.Infrastructure.Framework.Repositories
{
    public interface IRepository
    {
        //TEntity Get(TKey id);
        //void Save(TEntity entity);
        //void Delete(TEntity entity);

        T GetById<T>(int id) where T : IAggregate;

        CommandResponse CreateBookingFromRequest<T>(T item) where T : class, IAggregate;
    }
}