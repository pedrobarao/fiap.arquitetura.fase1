﻿using System.Text.RegularExpressions;
using Commons.Domain.Communication;

namespace Contatos.Domain.ValueObjects;

public record Email
{
    public const int MaxLength = 254;

    public Email()
    {
    }

    public Email(string endereco)
    {
        Endereco = endereco;
    }

    public string? Endereco { get; private set; }

    public override string ToString()
    {
        return Endereco;
    }

    public ValidationResult Validar()
    {
        var result = new ValidationResult();

        if (!ValidarFormatacao(Endereco)) result.Errors.Add("E-mail inválido.");

        return result;
    }

    public static bool ValidarFormatacao(string? email)
    {
        if (string.IsNullOrWhiteSpace(email)) return true;

        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!emailRegex.IsMatch(email)) return false;

        return true;
    }
}