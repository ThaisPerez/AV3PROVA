using Dominio.IRepositories;
using Historias.Imoveis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Factories;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/imoveis")]
    public class ImovelController : ControllerBase
    {
        private readonly CriarImovel _criarImovel;
        private readonly ConsultarImovel _consultarImovel;
        private readonly AlterarImovel _alterarImovel;
        private readonly ExcluirImovel _excluirImovel;

        public ImovelController(IImovelRepository imovelRepository)
        {
            _criarImovel = new CriarImovel(imovelRepository);
            _consultarImovel = new ConsultarImovel(imovelRepository);
            _alterarImovel = new AlterarImovel(imovelRepository);
            _excluirImovel = new ExcluirImovel(imovelRepository);
        }

        [HttpPost("criarUmImovel")]
        public async Task<IActionResult> Criar([FromBody] ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Todos os campos são obrigatórios" });

            var imovel = ImovelFactory.MapearImovel(imovelViewModel);

            await _criarImovel.Executar(imovel);

            return Ok(new { message ="imovel criado" });
        }

        [HttpPut("alterarUmImovel")]
        public async Task<IActionResult> Alterar([FromBody] ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = " Todos os campos são obrigatórios" });

            try
            {
                var imovel = ImovelFactory.MapearImovel(imovelViewModel);

                await _alterarImovel.Executar(imovelViewModel.Id, imovel);

                return Ok(new { mensagem = "Imovel foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { erro = "Erro ao alterar o imovel" });
            }
        }

        [HttpDelete("excluirumImovel/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _excluirImovel.Executar(id);

                return Ok(new { mensagem = "Imovel excluido com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { erro = "Erro ao excluir o imovel" });
            }
        }

        [HttpGet("buscarImovel/{id}")]
        public async Task<ImovelViewModel> BuscarPorId(int id)
        {
            var imovel = await _consultarImovel.BuscarPorId(id);

            if (imovel == null)
                return null;

            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);

            return imovelViewModel;
        }

        [HttpGet("buscarBairro/{id}")]
        public async Task<ImovelViewModel> BuscarBairro(string bairro)
        {
            var imovel = await _consultarImovel.BuscarBairro(bairro);

            if (imovel == null)
                return null;

            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);

            return imovelViewModel;
        }

        [HttpGet("listarPorCidade")]
        public async Task<IEnumerable<ImovelViewModel>> ListarCidade(string cidade)
        {
            var listaDeImoveis = await _consultarImovel.ListarCidade(cidade);

            if (listaDeImoveis == null)
                return null;

            var listaDeImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(listaDeImoveis);
            return listaDeImoveisViewModel;
        }

        [HttpGet("listarDeImoveis")]
        public async Task<IEnumerable<ImovelViewModel>> ListarTodosImoveis()
        {
            var listaDeImoveis = await _consultarImovel.ListarTodosImoveis();

            if (listaDeImoveis == null)
                return null;

            var listaDeImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(listaDeImoveis);
            return listaDeImoveisViewModel;
        }
    }
}
