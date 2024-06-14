using BuildingBlocks.Application;
using BuildingBlocks.Domain;

namespace BuildingBlocks.Infrastructure;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
