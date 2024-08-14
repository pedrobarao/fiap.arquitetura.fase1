using Fase1.Contatos.Application.DTOs.Outputs;
using Fase1.Contatos.Application.Mappings;
using Fase1.Contatos.Application.UseCases.Interfaces;
using Fase1.Contatos.Domain.Repositories;

namespace Fase1.Contatos.Application.UseCases;

public class ObterContatoUseCase(IContatoRepository contatoRepository) : IObterContatoUseCase
{
    public async Task<ObterContatoOutput?> ExecuteAsync(Guid id)
    {
        var contato = await contatoRepository.ObterContatoPorIdAsync(id);
        if (contato is null) return null;
        return ContatoMapping.ToObterContatoOutput(contato);
    }
}