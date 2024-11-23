namespace BlueAgenda.Dto.pessoa
{
    public class AgendaCriacaoDto
    {
        public required string Nome { get; set; }
        public int NumeroTelefone { get; set; }
        public required string Email { get; set; }
    }
}