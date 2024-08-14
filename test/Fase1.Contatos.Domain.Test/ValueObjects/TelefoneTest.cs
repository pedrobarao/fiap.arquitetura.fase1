using FluentAssertions;
using ContatoCollection = Fase1.Contatos.Domain.Test.Fixtures.ContatoCollection;
using ContatoFixture = Fase1.Contatos.Domain.Test.Fixtures.ContatoFixture;

namespace Fase1.Contatos.Domain.Test.ValueObjects;

[Collection(nameof(ContatoCollection))]
public class TelefoneTest
{
    private readonly ContatoFixture _fixture;

    public TelefoneTest(ContatoFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "Telefone com valores válidos deve estar válido")]
    [Trait("Category", "Telefone")]
    public void Telefone_ValoresValidos_DeveEstarValido()
    {
        // Arrange
        var telefone = _fixture.GerarTelefoneValido();

        // Act
        var result = telefone.Validar();

        // Assert
        result.IsValid.Should().BeTrue("o telefone deve estar válido");
    }

    [Fact(DisplayName = "Telefone com DDD nulo ou vazio deve falhar")]
    [Trait("Category", "Telefone")]
    public void Telefone_DddNuloOuVazio_DeveEstarInvalido()
    {
        // Arrange
        var dddNulo = _fixture.GerarTelefoneDddNulo();
        var dddVazio = _fixture.GerarTelefoneDddVazio();

        // Act
        var resultNulo = dddNulo.Validar();
        var resultVazio = dddVazio.Validar();

        // Assert
        resultNulo.IsValid.Should().BeFalse("o telefone deve estar inválido");
        resultVazio.IsValid.Should().BeFalse("o telefone deve estar inválido");
    }

    [Fact(DisplayName = "Telefone com número nulo ou vazio deve falhar")]
    [Trait("Category", "Telefone")]
    public void Telefone_NumeroNuloOuVazio_DeveEstarInvalido()
    {
        // Arrange
        var numeroNulo = _fixture.GerarTelefoneNumeroNulo();
        var numeroVazio = _fixture.GerarTelefoneNumeroVazio();

        // Act
        var resultNulo = numeroNulo.Validar();
        var resultVazio = numeroVazio.Validar();

        // Assert
        resultNulo.IsValid.Should().BeFalse("o telefone deve estar inválido");
        resultVazio.IsValid.Should().BeFalse("o telefone deve estar inválido");
    }

    [Fact(DisplayName = "Telefone válido deve retornar número completo corretamente")]
    [Trait("Category", "Telefone")]
    public void Telefone_Valido_DeveRetornarNumeroCompletoCorretamente()
    {
        // Arrange
        var telefone = _fixture.GerarTelefoneValido();

        // Act
        var numeroCompleto = telefone.ToString();

        // Assert
        Assert.Equal($"{telefone.Ddd}{telefone.Numero}", numeroCompleto);
    }
}