namespace Fase1.Commons.Domain.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}