﻿using Bogus;
using Contatos.Domain.Entities;
using Contatos.Domain.ValueObjects;

namespace Contatos.Domain.Test.Fixtures;

[CollectionDefinition(nameof(ContatoCollection))]
public class ContatoCollection : ICollectionFixture<ContatoFixture>
{
}

public sealed class ContatoFixture : IDisposable
{
    private readonly Faker _faker;

    public ContatoFixture()
    {
        _faker = new Faker("pt_BR");
    }

    public void Dispose()
    {
    }

    public Nome GerarNome(string nome, string? sobrenome = null)
    {
        return new Nome(nome, sobrenome);
    }

    public Nome GerarNomeValido()
    {
        return GerarNome(_faker.Person.FirstName, _faker.Person.LastName);
    }

    public Nome GerarNomePrimeiroNomeNulo()
    {
        return GerarNome(null!, _faker.Person.LastName);
    }

    public Nome GerarNomePrimeiroNomeVazio()
    {
        return GerarNome(string.Empty, _faker.Person.LastName);
    }

    public Email GerarEmail(string endereco)
    {
        return new Email(endereco);
    }

    public Email GerarEmailValido()
    {
        return GerarEmail(_faker.Person.Email);
    }

    public Email GerarEmailNulo()
    {
        return new Email(null!);
    }

    public Email GerarEmailVazio()
    {
        return new Email(null!);
    }

    public Email GerarEmailInvalido()
    {
        return new Email("invalido");
    }


    public Telefone GerarTelefone(string ddd, string numero, TipoTelefone tipo)
    {
        return new Telefone(ddd, numero, tipo);
    }

    public Telefone GerarTelefoneValido()
    {
        var tipo = _faker.Random.Enum<TipoTelefone>();
        var ddd = _faker.Random.Int(11, 99);
        var numero = _faker.Random.Replace("9########");

        if (tipo != TipoTelefone.Celular) numero = numero.Remove(0, 1);

        return GerarTelefone(ddd.ToString(), numero, tipo);
    }

    public Telefone GerarTelefoneDddNulo()
    {
        return GerarTelefone(null!, _faker.Random.Replace("9########"), TipoTelefone.Celular);
    }

    public Telefone GerarTelefoneDddVazio()
    {
        return GerarTelefone(string.Empty, _faker.Random.Replace("9########"), TipoTelefone.Celular);
    }

    public Telefone GerarTelefoneNumeroNulo()
    {
        return GerarTelefone(_faker.Random.Int(11, 99).ToString(), null!, TipoTelefone.Celular);
    }

    public Telefone GerarTelefoneNumeroVazio()
    {
        return GerarTelefone(_faker.Random.Int(11, 99).ToString(), string.Empty, TipoTelefone.Celular);
    }

    public Contato GerarContato(Nome nome, Telefone telefone, Email email)
    {
        return new Contato(nome, [telefone], email);
    }

    public Contato GerarContatoValido()
    {
        var nome = GerarNomeValido();
        var telefone = GerarTelefoneValido();
        var email = GerarEmailValido();
        return GerarContato(nome, telefone, email);
    }

    public Contato GerarContatoInvalido()
    {
        var nome = GerarNomePrimeiroNomeNulo();
        var telefone = GerarTelefoneNumeroNulo();
        var email = GerarEmailInvalido();
        return GerarContato(nome, telefone, email);
    }

    public Contato GerarContatoComNomeInvalido()
    {
        var nome = GerarNomePrimeiroNomeNulo();
        var telefone = GerarTelefoneValido();
        var email = GerarEmailValido();
        return GerarContato(nome, telefone, email);
    }

    public Contato GerarContatoComEmailInvalido()
    {
        var nome = GerarNomeValido();
        var telefone = GerarTelefoneValido();
        var email = GerarEmailInvalido();
        return GerarContato(nome, telefone, email);
    }

    public Contato GerarContatoComTelefoneInvalido()
    {
        var nome = GerarNomeValido();
        var telefone = GerarTelefoneNumeroNulo();
        var email = GerarEmailValido();
        return GerarContato(nome, telefone, email);
    }
}