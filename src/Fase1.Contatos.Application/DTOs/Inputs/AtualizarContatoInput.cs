using System.ComponentModel.DataAnnotations;
using Fase1.Contatos.Domain.ValueObjects;

namespace Fase1.Contatos.Application.DTOs.Inputs;

public class AtualizarContatoInput
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Nome { get; set; }

    public string? Sobrenome { get; set; }
    public IList<Telefone> Telefones { get; set; }
    public string? Email { get; set; }
}