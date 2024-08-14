using Fase1.Commons.Domain.Communication;
using Fase1.Contatos.Application.DTOs.Outputs;
using Fase1.Contatos.Application.Mappings;
using Fase1.Contatos.Application.UseCases.Interfaces;
using Fase1.Contatos.Domain.Repositories;

namespace Fase1.Contatos.Application.UseCases;

public class ListarContatoUseCase(IContatoRepository contatoRepository)
    : IListarContatoUseCase
{
    public async Task<PagedResult<ObterContatoOutput>> ExecuteAsync(int pageSize, int pageIndex, string? query = null)
    {
        var contatosPaginados = await contatoRepository.ObterContatosPaginados(pageSize, pageIndex, query);
        return ContatoMapping.ToPagedContatoResponse(contatosPaginados);
    }
}