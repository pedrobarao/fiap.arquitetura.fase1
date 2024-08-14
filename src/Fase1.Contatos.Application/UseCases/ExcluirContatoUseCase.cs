using Fase1.Commons.Domain.DomainObjects;
using Fase1.Contatos.Application.UseCases.Interfaces;
using Fase1.Contatos.Domain.Repositories;

namespace Fase1.Contatos.Application.UseCases;

public class ExcluirContatoUseCase(IContatoRepository contatoRepository) : IExcluirContatoUseCase
{
    public async Task ExecuteAsync(Guid id)
    {
        var contato = await contatoRepository.ObterContatoPorIdAsync(id);

        if (contato is null) throw new DomainException("Contato inválido");

        contatoRepository.Excluir(contato);
        await contatoRepository.UnitOfWork.Commit();
    }
}