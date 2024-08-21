using System.Text.RegularExpressions;
using Commons.Domain.Communication;
using Infra.CrossCutting.Utils;

namespace Contatos.Domain.ValueObjects;

public record Telefone
{
    protected Telefone()
    {
    }

    public Telefone(string ddd, string numero, TipoTelefone tipo)
    {
        Ddd = ddd;
        Numero = StringUtil.JustNumbers(numero);
        Tipo = tipo;
    }

    public Guid ContatoId { get; set; }
    public string Ddd { get; init; } = null!;
    public string Numero { get; init; } = null!;
    public TipoTelefone Tipo { get; init; }

    public void AssociarContato(Guid contatoId)
    {
        ContatoId = contatoId;
    }

    public override string ToString()
    {
        return $"{Ddd}{Numero}";
    }

    public ValidationResult Validar()
    {
        var result = new ValidationResult();

        if (!ValidarFormato(Ddd, Numero, Tipo)) result.Errors.Add($"Telefone {ToString()} inválido.");

        return result;
    }

    public static bool ValidarFormato(string ddd, string numero, TipoTelefone tipo)
    {
        numero = StringUtil.JustNumbers(numero);
        var numeroComDdd = $"{ddd}{numero}";

        if (string.IsNullOrWhiteSpace(numeroComDdd)) return false;

        if (numeroComDdd.Length != 10 && numeroComDdd.Length != 11) return false;

        if (!Regex.IsMatch(numeroComDdd, "^[1-9][0-9]")) return false;

        if (tipo == TipoTelefone.Celular && numero.Length == 11 && !numero.StartsWith('9')) return false;

        return true;
    }
}