using Fase1.Commons.Domain.Communication;
using Fase1.Contatos.Application.DTOs.Inputs;
using Fase1.Contatos.Application.DTOs.Outputs;
using Fase1.Contatos.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fase1.Contatos.Api.Controllers;

[Route("api/v1/contatos")]
public class ContatoController(
    ILogger<ContatoController> logger,
    IListarContatoUseCase listarContatoUseCase,
    IObterContatoUseCase obterContatoUseCase,
    ICadastrarContatoUseCase cadastrarContatoUseCase,
    IAtualizarContatoUseCase atualizarContatoUseCase,
    IExcluirContatoUseCase excluirContatoUseCase) : CustomBaseController
{
    /// <summary>
    ///     Lista os contatos de acordo com o filtro informado.
    /// </summary>
    /// <param name="pageSize">Quantidade de items que serão retornados por página.</param>
    /// <param name="pageIndex">Índice de página que deseja recuperar (a primeira página é o índice 0).</param>
    /// <param name="query">Filtro de nome e sobrenome para consulta.</param>
    /// <response code="200">
    ///     Retorna uma lista de contatos paginada. Se nenhum contato corresponder ao filtro informado uma
    ///     lista vazia é retornada.
    /// </response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<ObterContatoOutput>))]
    [Produces("application/json")]
    [HttpGet]
    public async Task<IActionResult> Listar(int pageSize = 10, int pageIndex = 0, string? query = null)
    {
        return Respond(Ok(await listarContatoUseCase.ExecuteAsync(pageSize, pageIndex, query)));
    }

    /// <summary>
    ///     Obtém um contato por id.
    /// </summary>
    /// <param name="id">Id do contato</param>
    /// <response code="200">Retorna o contato para o id informado</response>
    /// <response code="404">Contato não encontrado para o id informado.</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObterContatoOutput))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(Guid id)
    {
        var result = await obterContatoUseCase.ExecuteAsync(id);
        return result is not null ? Respond(Ok(result)) : NotFound();
    }

    /// <summary>
    ///     Criar um contato.
    /// </summary>
    /// <param name="input">Dados do contato.</param>
    /// <response code="201">Contato criado com sucesso.</response>
    /// <response code="400">O contato enviado é inválido.</response>
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContatoCriadoOutput))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] NovoContatoInput input)
    {
        var result = await cadastrarContatoUseCase.ExecuteAsync(input);

        if (!result.IsSuccess)
        {
            AddErrors(result.Errors);
            return Respond();
        }

        return Respond(Created($"contatos/{result.Data.Id}", result.Data));
    }

    /// <summary>
    ///     Atualizar dados de um contato.
    /// </summary>
    /// <param name="id">Id do contato (obrigatório).</param>
    /// <param name="input">Dados do contato.</param>
    /// <response code="200">Contato atualizado com sucesso.</response>
    /// <response code="400">O contato enviado é inválido.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarContatoInput input)
    {
        if (input.Id != id)
        {
            AddError("O id informado no corpo da requisição é diferente do id informado na URL.");
            return Respond();
        }

        return Respond(Ok(await atualizarContatoUseCase.ExecuteAsync(input)));
    }

    /// <summary>
    ///     Excluir um contato.
    /// </summary>
    /// <param name="id">id do contato (obrigatório).</param>
    /// <response code="204">Contato excluído com sucesso.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Produces("application/json")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(Guid id)
    {
        await excluirContatoUseCase.ExecuteAsync(id);
        return Respond();
    }
}