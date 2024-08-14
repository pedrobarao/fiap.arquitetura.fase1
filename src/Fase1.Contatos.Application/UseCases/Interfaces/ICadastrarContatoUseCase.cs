using Fase1.Commons.Domain.Communication;
using Fase1.Contatos.Application.DTOs.Inputs;
using Fase1.Contatos.Application.DTOs.Outputs;

namespace Fase1.Contatos.Application.UseCases.Interfaces;

public interface ICadastrarContatoUseCase
{
    public Task<Result<ContatoCriadoOutput>> ExecuteAsync(NovoContatoInput input);
}