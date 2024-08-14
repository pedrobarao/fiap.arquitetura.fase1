using Fase1.Commons.Domain.Communication;
using Fase1.Contatos.Application.DTOs.Outputs;
using Fase1.Contatos.Domain.Entities;

namespace Fase1.Contatos.Application.Mappings;

public class ContatoMapping
{
    public static PagedResult<ObterContatoOutput> ToPagedContatoResponse(PagedResult<Contato> contatosPaginados)
    {
        var contatosResponse = contatosPaginados.Items.Select(ToObterContatoOutput).ToList();

        return new PagedResult<ObterContatoOutput>
        {
            Items = contatosResponse,
            TotalItems = contatosPaginados.TotalItems,
            TotalPages = contatosPaginados.TotalPages,
            PageIndex = contatosPaginados.PageIndex,
            PageSize = contatosPaginados.PageSize,
            Filter = contatosPaginados.Filter
        };
    }

    public static ObterContatoOutput ToObterContatoOutput(Contato contato)
    {
        return new ObterContatoOutput
        {
            Id = contato.Id,
            Nome = contato.Nome.PrimeiroNome,
            Sobrenome = contato.Nome.Sobrenome,
            Email = contato.Email?.Endereco,
            Telefones = contato.Telefones.Select(t => new ObterContatoOutput.TelefoneOutput
            {
                Numero = t.Numero,
                Tipo = t.Tipo.ToString(),
                Ddd = t.Ddd
            }).ToList()
        };
    }
}