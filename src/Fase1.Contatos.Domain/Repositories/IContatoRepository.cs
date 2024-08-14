using Fase1.Commons.Domain.Communication;
using Fase1.Commons.Domain.Data;
using Fase1.Contatos.Domain.Entities;

namespace Fase1.Contatos.Domain.Repositories;

public interface IContatoRepository : IRepository<Contato>
{
    void Adicionar(Contato contato);
    Task<Contato?> ObterContatoPorIdAsync(Guid id, bool tracking = false);
    Task<PagedResult<Contato>> ObterContatosPaginados(int pageSize, int pageIndex, string? query = null);
    void Atualizar(Contato contato);
    void Excluir(Contato contato);
}