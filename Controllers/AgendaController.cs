using BlueAgenda.Dto.Autor;
using BlueAgenda.Dto.pessoa;
using BlueAgenda.Models;
using BlueAgenda.services.BlueAgenda;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaInterface _agendaInterface;
        public AgendaController(IAgendaInterface agendaInterface)
        {
            _agendaInterface = agendaInterface;
        }


        [HttpGet("ListarPessoas")]
        public async Task<ActionResult<ResponseModel<List<AgendaModel>>>> ListarPessoas()
        {
            var pessoas = await _agendaInterface.ListarPessoas();
            return Ok(pessoas);
        }


        [HttpGet("BuscarPessoaPorId/{idPessoa}")]
        public async Task<ActionResult<ResponseModel<AgendaModel>>> BuscarPessoaPorId(int idPessoa)
        {
            var pessoa = await _agendaInterface.BuscarPessoaPorId(idPessoa);
            return Ok(pessoa);
        }

        [HttpGet("BuscarNumeroTelefone/{numeroTelefone}")]
        public async Task<ActionResult<ResponseModel<AgendaModel>>> BuscarNumeroTelefone(int numeroTelefone)
        {
            var numerotelefone = await _agendaInterface.BuscarNumeroTelefone(numeroTelefone);
            return Ok(numerotelefone);
        }



        [HttpPost("AdicionarPessoa")]
        public async Task<ActionResult<ResponseModel<List<AgendaModel>>>> AdicionarPessoa(AgendaCriacaoDto agendaCriacaoDto)
        {
            var npessoa = await _agendaInterface.AdicionarPessoa(agendaCriacaoDto);
            return Ok(npessoa);
        }


        [HttpPut("EditarPessoa")]
        public async Task<ActionResult<ResponseModel<List<AgendaModel>>>> EditarPessoa(AgendaEdicaoDto agendaEdicaoDto)
        {
            var edpessoa = await _agendaInterface.EditarPessoa(agendaEdicaoDto);
            return Ok(edpessoa);
        }


        [HttpDelete("RemoverPessoa")]
        public async Task<ActionResult<ResponseModel<List<AgendaModel>>>> RemoverPessoa(int idPessoa)
        {
            var repessoa = await _agendaInterface.RemoverPessoa(idPessoa);
            return Ok(repessoa);
        }


    }

}