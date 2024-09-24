﻿using Bogus;
using Contatos.Domain.Entities;
using Contatos.Domain.ValueObjects;

namespace Test.Commons.Builders.ValueObjects;

public class NomeBuilder
{
    private readonly Faker<Nome> _faker = new()
    {
        Locale = "pt_BR"
    };

    public NomeBuilder()
    {
        _faker.CustomInstantiator(f => new Nome(
            f.Person.FirstName,
            f.Person.LastName
        ));
    }

    public NomeBuilder ComPrimeiroNome(string primeiroNome)
    {
        _faker.RuleFor(x => x.PrimeiroNome, primeiroNome);
        return this;
    }

    public NomeBuilder ComSobrenomeNulo()
    {
        string? sobrenome = null;
        _faker.RuleFor(x => x.Sobrenome, sobrenome);
        return this;
    }
    
    public NomeBuilder ComSobrenomeVazio()
    {
        _faker.RuleFor(x => x.Sobrenome, "");
        return this;
    }

    public Nome Build()
    {
        return _faker.Generate();
    }
}