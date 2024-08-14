using System.Text.RegularExpressions;
using Fase1.Commons.Domain.Communication;
using Fase1.Infra.CrossCutting.Utils;

namespace Fase1.Contatos.Domain.ValueObjects;

public record Telefone
{
    public Telefone()
    {
    }

    public Telefone(string ddd, string numero, TipoTelefone tipo)
    {
        Ddd = ddd;
        Numero = StringUtil.JustNumbers(numero);
        Tipo = tipo;
    }

    public string Ddd { get; init; }
    public string Numero { get; init; }
    public TipoTelefone Tipo { get; init; }

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