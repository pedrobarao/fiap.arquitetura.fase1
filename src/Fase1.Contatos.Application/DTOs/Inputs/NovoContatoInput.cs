using System.ComponentModel.DataAnnotations;
using Fase1.Contatos.Domain.ValueObjects;

namespace Fase1.Contatos.Application.DTOs.Inputs;

public class NovoContatoInput
{
    /// <summary>
    ///     Nome do contato (obrigatório).
    /// </summary>
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Nome { get; set; }

    /// <summary>
    ///     Sobrenome do contato (opcional).
    /// </summary>
    public string? Sobrenome { get; set; }

    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public IList<Telefone> Telefones { get; set; }

    public string? Email { get; set; }
}