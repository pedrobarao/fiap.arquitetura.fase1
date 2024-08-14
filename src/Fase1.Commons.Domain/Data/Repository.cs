using Fase1.Commons.Domain.DomainObjects;

namespace Fase1.Commons.Domain.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}