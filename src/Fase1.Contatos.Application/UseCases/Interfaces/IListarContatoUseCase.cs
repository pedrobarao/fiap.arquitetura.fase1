using Fase1.Commons.Domain.Communication;
using Fase1.Contatos.Application.DTOs.Outputs;

namespace Fase1.Contatos.Application.UseCases.Interfaces;

public interface IListarContatoUseCase
{
    Task<PagedResult<ObterContatoOutput>> ExecuteAsync(int pageSize, int pageIndex, string? query = null);
}