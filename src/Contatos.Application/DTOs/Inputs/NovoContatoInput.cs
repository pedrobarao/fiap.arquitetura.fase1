using System.ComponentModel.DataAnnotations;
using Contatos.Domain.ValueObjects;

namespace Contatos.Application.DTOs.Inputs;

public class NovoContatoInput
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Nome { get; set; }
    
    public string? Sobrenome { get; set; }

    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public IList<Telefone> Telefones { get; set; }

    public string? Email { get; set; }
}