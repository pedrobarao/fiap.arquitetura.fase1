namespace Fase1.Contatos.Application.DTOs.Outputs;

public class ObterContatoOutput
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Sobrenome { get; set; }
    public IList<TelefoneOutput> Telefones { get; set; }
    public string? Email { get; set; }

    public class TelefoneOutput
    {
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
    }
}