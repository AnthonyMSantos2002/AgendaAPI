using BlueAgenda.Dto.Autor;
using BlueAgenda.Dto.pessoa;
using BlueAgenda.Models;

namespace BlueAgenda.services.BlueAgenda
{
    public interface IAgendaInterface
    {
        Task<ResponseModel<List<AgendaModel>>> ListarPessoas();
        Task<ResponseModel<AgendaModel>> BuscarPessoaPorId(int idPessoa);
        Task<ResponseModel<AgendaModel>> BuscarNumeroTelefone(int numeroTelefone);
        Task<ResponseModel<List<AgendaModel>>> AdicionarPessoa(AgendaCriacaoDto agendaCriacaoDto);
        Task<ResponseModel<List<AgendaModel>>>EditarPessoa(AgendaEdicaoDto agendaEdicaoDto);
        Task<ResponseModel<List<AgendaModel>>>RemoverPessoa(int idPessoa);


    }
}