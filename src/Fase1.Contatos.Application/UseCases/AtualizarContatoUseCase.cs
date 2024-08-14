using Fase1.Commons.Domain.Communication;
using Fase1.Commons.Domain.DomainObjects;
using Fase1.Contatos.Application.DTOs.Inputs;
using Fase1.Contatos.Application.UseCases.Interfaces;
using Fase1.Contatos.Domain.Repositories;
using Fase1.Contatos.Domain.ValueObjects;

namespace Fase1.Contatos.Application.UseCases;

public class AtualizarContatoUseCase(IContatoRepository contatoRepository) : IAtualizarContatoUseCase
{
    private readonly Result _result = new();

    public async Task<Result> ExecuteAsync(AtualizarContatoInput input)
    {
        var contato = await contatoRepository.ObterContatoPorIdAsync(input.Id, true);

        if (contato is null) throw new DomainException("Contato inválido.");

        var nome = new Nome(input.Nome, input.Sobrenome);

        Email? email = null;
        if (!string.IsNullOrWhiteSpace(input.Email)) email = new Email(input.Email);
        var telefones = input.Telefones.Select(t => new Telefone(t.Ddd, t.Numero, t.Tipo)).ToList();

        contato.AtualizarNome(nome);
        contato.AtualizarEmail(email);
        contato.AtualizarTelefones(telefones);

        var validationResult = contato.Validar();

        if (!validationResult.IsValid)
        {
            _result.Errors.AddRange(validationResult.Errors);
            return _result;
        }

        contatoRepository.Atualizar(contato);
        await contatoRepository.UnitOfWork.Commit();
        return _result;
    }
}