using Contatos.Application.Test.Fixtures;
using Contatos.Application.UseCases;
using Contatos.Domain.Repositories;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace Contatos.Application.Test.UseCases;

[Collection(nameof(ContatoCollection))]
public class ObterContatoUseCaseTest
{
    private readonly ContatoFixture _fixture;
    private readonly AutoMocker _mocker;

    public ObterContatoUseCaseTest(ContatoFixture fixture)
    {
        _fixture = fixture;
        _mocker = new AutoMocker();
    }

    [Fact(DisplayName = "Obter contato encontrado deve obter contato com sucesso")]
    [Trait("Category", "ObterContatoUseCase")]
    public async Task ObterContatoUseCase_Encontrado_DeveObterContatoComSucesso()
    {
        // Arrange
        var contato = _fixture.GerarContatoValido();
        _mocker.GetMock<IContatoRepository>().Setup(r =>
                r.ObterContatoPorIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
            .ReturnsAsync(contato);
        var useCase = _mocker.CreateInstance<ObterContatoUseCase>();

        // Act
        var result = await useCase.ExecuteAsync(contato.Id);

        // Assert
        result.Should().NotBeNull("deve retornar o contato");
    }

    [Fact(DisplayName = "Obter contato não encontrado deve retornar nulo")]
    [Trait("Category", "ObterContatoUseCase")]
    public async Task ObterContatoUseCase_NaoEncontrado_DeveRetornarNulo()
    {
        // Arrange
        _mocker.GetMock<IContatoRepository>().Setup(r =>
                r.ObterContatoPorIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
            .ReturnsAsync(() => null);
        var useCase = _mocker.CreateInstance<ObterContatoUseCase>();

        // Act
        var result = await useCase.ExecuteAsync(It.IsAny<Guid>());

        // Assert
        result.Should().BeNull("deve retornar nulo");
    }
}