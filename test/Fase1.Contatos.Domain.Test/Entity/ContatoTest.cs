using FluentAssertions;
using ContatoCollection = Fase1.Contatos.Domain.Test.Fixtures.ContatoCollection;
using ContatoFixture = Fase1.Contatos.Domain.Test.Fixtures.ContatoFixture;

namespace Fase1.Contatos.Domain.Test.Entity;

[Collection(nameof(ContatoCollection))]
public class ContatoTest
{
    private readonly ContatoFixture _fixture;

    public ContatoTest(ContatoFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "Contato com valores válidos deve estar válido")]
    [Trait("Category", "Contato")]
    public void Contato_ValoresValidos_DeveEstarValido()
    {
        // Arrange
        var contato = _fixture.GerarContatoValido();

        // Act
        var result = contato.Validar();

        // Assert
        result.IsValid.Should().BeTrue("o contato deve estar válido");
    }

    [Fact(DisplayName = "Contato com nome inválido deve estar inválido")]
    [Trait("Category", "Contato")]
    public void Contato_ComNomeInvalido_DeveEstarInvalido()
    {
        // Arrange
        var contato = _fixture.GerarContatoComNomeInvalido();

        // Act
        var result = contato.Validar();

        // Assert
        result.IsValid.Should().BeFalse("o contato deve estar inválido");
    }

    [Fact(DisplayName = "Contato com e-mail inválido deve estar inválido")]
    [Trait("Category", "Contato")]
    public void Contato_EmailInvalido_DeveEstarInvalido()
    {
        // Arrange
        var contato = _fixture.GerarContatoComEmailInvalido();

        // Act
        var result = contato.Validar();

        // Assert
        result.IsValid.Should().BeFalse("o contato deve estar inválido");
    }

    [Fact(DisplayName = "Contato com telefone inválido deve estar inválido")]
    [Trait("Category", "Contato")]
    public void Contato_TelefoneInvalido_DeveEstarInvalido()
    {
        // Arrange
        var contato = _fixture.GerarContatoComTelefoneInvalido();

        // Act
        var result = contato.Validar();

        // Assert
        result.IsValid.Should().BeFalse("o contato deve estar inválido");
    }
}