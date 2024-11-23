using BlueAgenda.Data;
using BlueAgenda.Dto.Autor;
using BlueAgenda.Dto.pessoa;
using BlueAgenda.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace BlueAgenda.services.BlueAgenda
{
    public class AgendaService : IAgendaInterface
    {

        private readonly AppDbContext _context;
        public AgendaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AgendaModel>>> AdicionarPessoa(AgendaCriacaoDto agendaCriacaoDto)
        {
            ResponseModel<List<AgendaModel>> resposta = new ResponseModel<List<AgendaModel>>();

            try
            {
                var npessoa = new AgendaModel()
                {
                    Nome = agendaCriacaoDto.Nome,
                    NumeroTelefone = agendaCriacaoDto.NumeroTelefone,
                    Email = agendaCriacaoDto.Email
                };

                _context.Add(npessoa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Agenda.ToListAsync();
                resposta.Mensagem = "Pessoa Criada com sucesso!! nice dms";

                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }



        public async Task<ResponseModel<AgendaModel>> BuscarNumeroTelefone(int numeroTelefone)
        {
            ResponseModel<AgendaModel> resposta = new ResponseModel<AgendaModel>();
            try
            {
                var numerotelefone = await _context.Agenda.FirstOrDefaultAsync(numerotelefoneBanco => numerotelefoneBanco.NumeroTelefone == numeroTelefone);
                


                if(numerotelefone == null)
                {
                    resposta.Mensagem = "Não achamos essa numero de telefone!";
                    return resposta;
                }

                resposta.Dados = numerotelefone;
                resposta.Mensagem = "numero de telefone localizada com sucesso ebaa!";

                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AgendaModel>> BuscarPessoaPorId(int idPessoa)
        {

            ResponseModel<AgendaModel> resposta = new ResponseModel<AgendaModel>();
            try
            {
                var pessoa = await _context.Agenda.FirstOrDefaultAsync(pessoaBanco => pessoaBanco.Id == idPessoa);

                if(pessoa == null)
                {
                    resposta.Mensagem = "Não achamos essa pessoas no nosso banco de dados!!";
                    return resposta;
                }

                resposta.Dados = pessoa;
                resposta.Mensagem = "Pessoa localizada com sucesso ebaa!";

                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<AgendaModel>>> EditarPessoa(AgendaEdicaoDto agendaEdicaoDto)
        {
            ResponseModel<List<AgendaModel>> resposta = new ResponseModel<List<AgendaModel>>();
            try
            {
                var edpessoa = await _context.Agenda.FirstOrDefaultAsync(agendaBanco => agendaBanco.Id == agendaEdicaoDto.Id);

                if(edpessoa == null)
                {
                    resposta.Mensagem = "Não foi encontrado essa pessoa no nosso banco de dados!";
                    return resposta;
                }
                edpessoa.Nome = agendaEdicaoDto.Nome;
                edpessoa.NumeroTelefone = agendaEdicaoDto.NumeroTelefone;
                edpessoa.Email = agendaEdicaoDto.Email;

                _context.Update(edpessoa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Agenda.ToListAsync();
                resposta.Mensagem = "Pessoa editada com sucesso!";
                return resposta;
                
            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AgendaModel>>> ListarPessoas()
        {

            ResponseModel<List<AgendaModel>> resposta = new ResponseModel<List<AgendaModel>>();
            try
            {
                var pessoas = await _context.Agenda.ToListAsync();

                resposta.Dados = pessoas;
                resposta.Mensagem = "Todas as pessoas foram procuradas!!!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AgendaModel>>> RemoverPessoa(int idPessoa)
        {
            ResponseModel<List<AgendaModel>> resposta = new ResponseModel<List<AgendaModel>>();

            try
            {
                var repessoa = await _context.Agenda.FirstOrDefaultAsync(AgendaBanco => AgendaBanco.Id == idPessoa);

                if(repessoa == null)
                {
                    resposta.Mensagem = "Não foi encontrado essa pessoa no nosso banco de dados!";
                    return resposta;
                }

                _context.Remove(repessoa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Agenda.ToListAsync();
                resposta.Mensagem = "Pessoa removida do banco de dados com sucesso!";
                return resposta;


            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }


}