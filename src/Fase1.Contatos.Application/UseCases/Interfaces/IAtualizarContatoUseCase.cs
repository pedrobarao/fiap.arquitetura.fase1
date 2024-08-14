using Fase1.Commons.Domain.Communication;
using Fase1.Contatos.Application.DTOs.Inputs;

namespace Fase1.Contatos.Application.UseCases.Interfaces;

public interface IAtualizarContatoUseCase
{
    Task<Result> ExecuteAsync(AtualizarContatoInput input);
}