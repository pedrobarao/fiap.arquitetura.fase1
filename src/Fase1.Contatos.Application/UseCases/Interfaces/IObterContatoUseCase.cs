using Fase1.Contatos.Application.DTOs.Outputs;

namespace Fase1.Contatos.Application.UseCases.Interfaces;

public interface IObterContatoUseCase
{
    Task<ObterContatoOutput?> ExecuteAsync(Guid id);
}