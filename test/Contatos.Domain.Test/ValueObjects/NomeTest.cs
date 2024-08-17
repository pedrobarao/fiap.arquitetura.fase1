using Contatos.Domain.Test.Fixtures;
using FluentAssertions;

namespace Contatos.Domain.Test.ValueObjects;

[Collection(nameof(ContatoCollection))]
public class NomeTest
{
    private readonly ContatoFixture _fixture;

    public NomeTest(ContatoFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "Nome com valores válidos deve estar válido")]
    [Trait("Category", "Nome")]
    public void Nome_ValoresValidos_DeveEstarValido()
    {
        // Arrange
        var nome = _fixture.GerarNomeValido();

        // Act
        var result = nome.Validar();

        // Assert
        result.IsValid.Should().BeTrue("o nome deve estar válido");
    }

    [Fact(DisplayName = "Nome com primeiro nome nulo ou vazio deve falhar")]
    [Trait("Category", "Nome")]
    public void Nome_PrimeiroNomeNuloOuVazio_DeveEstarInvalido()
    {
        // Arrange
        var primeiroNomeNulo = _fixture.GerarNomePrimeiroNomeNulo();
        var primeiroNomeVazio = _fixture.GerarNomePrimeiroNomeVazio();

        // Act
        var resultNulo = primeiroNomeNulo.Validar();
        var resultVazio = primeiroNomeVazio.Validar();

        // Assert
        resultNulo.IsValid.Should().BeFalse("o nome deve estar inválido");
        resultVazio.IsValid.Should().BeFalse("o nome deve estar inválido");
    }

    [Fact(DisplayName = "Nome válido deve retornar nome completo corretamente")]
    [Trait("Category", "Nome")]
    public void Nome_NomeValido_DeveRetornarNomeCompletoCorretamente()
    {
        // Arrange
        var nome = _fixture.GerarNomeValido();

        // Act
        var nomeCompleto = nome.ToString();

        // Assert
        Assert.Equal($"{nome.PrimeiroNome} {nome.Sobrenome}", nomeCompleto);
    }
}