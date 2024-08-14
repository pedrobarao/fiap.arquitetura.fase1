using Fase1.Contatos.Domain.ValueObjects;

namespace Fase1.Contatos.Application.DTOs.Outputs;

public class ContatoAtualizadoOutput
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Sobrenome { get; set; }
    public IList<Telefone> Telefones { get; set; }
    public string? Email { get; set; }
}