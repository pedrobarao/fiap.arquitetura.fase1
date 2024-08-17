using Contatos.Domain.ValueObjects;

namespace Contatos.Application.DTOs.Outputs;

public class ContatoAtualizadoOutput
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Sobrenome { get; set; }
    public IList<Telefone> Telefones { get; set; }
    public string? Email { get; set; }
}