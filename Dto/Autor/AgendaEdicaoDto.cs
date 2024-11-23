namespace BlueAgenda.Dto.Autor
{
    public class AgendaEdicaoDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int NumeroTelefone { get; set; }
        public required string Email { get; set; }
    }
}