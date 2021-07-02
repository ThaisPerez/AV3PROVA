using CasaNova.Api.Factories;
using CasaNova.Api.ViewModels;
using CasaNova.Dominio.IRepositorios;
using CasaNova.Historias.Imoveis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaNova.Api.Controllers
{
    [Route("api/imoveis")]
    public class ImovelController : Controller
    {
        private readonly CriarImovel _criarimovel;
        private readonly ConsultarImovel _consultarimovel;
        private readonly AlterarImovel _alterarimovel;
        private readonly ExcluirImovel _excluirimovel;

        public ImovelController(IImovelRepository imovelRepository)
        {
            _criarimovel = new CriarImovel(imovelRepository);
            _consultarimovel = new ConsultarImovel(imovelRepository);
            _alterarimovel = new AlterarImovel(imovelRepository);
            _excluirimovel = new ExcluirImovel(imovelRepository);
        }

        [HttpPost("criar-imovel")]
        public async Task<IActionResult> Criar([FromBody] ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Todos os campos são obrigatórios" });

            var imovel = ImovelFactory.MapearImovel(imovelViewModel);

            await _criarimovel.Executar(imovel);

            return Ok(new { message = "imovel criado com sucesso" });
        }

        [HttpPut("alterar-imovel")]
        public async Task<IActionResult> Alterar([FromBody] ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Todos os campos são obrigatórios" });

            try
            {
                var imovel = ImovelFactory.MapearImovel(imovelViewModel);

                await _alterarimovel.Executar(imovelViewModel.Id, imovel);

                return Ok(new { mensagem = "imovel atualizado com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { erro = "Erro ao alterar o imovel" });
            }
        }

        [HttpDelete("excluir-imovel/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _excluirimovel.Executar(id);

                return Ok(new { mensagem = "imovel excluido com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { erro = "Erro ao excluir o imovel" });
            }
        }

        [HttpGet("buscar-imovel-por-id/{id}")]
        public async Task<ImovelViewModel> BuscarPorId(int id)
        {
            var imovel = await _consultarimovel.BuscarPorId(id);

            if (imovel == null)
                return null;

            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);
            return imovelViewModel;
        }

        [HttpGet("buscar-imovel-por-cidade/{id}")]
        public async Task<IEnumerable<ImovelViewModel>> ListarPorCidade(string cidade)
        {
            var listaDeImoveis = await _consultarimovel.ListarCidade(cidade);

            if (listaDeImoveis == null)
                return null;

            var listaDeImovelViewModel = ImovelFactory.MapearListaImovelViewModel(listaDeImoveis);
            return listaDeImovelViewModel;
        }

        [HttpGet("listar-imoveis-por-bairro")]
        public async Task<ImovelViewModel> BuscarPorBairro(string bairro)
        {
            var imovel = await _consultarimovel.BuscarBairro(bairro);

            if (imovel == null)
                return null;

            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);
            return imovelViewModel;
        }

        [HttpGet("listar-imoveis")]
        public async Task<IEnumerable<ImovelViewModel>> ListarTodosimoveis()
        {
            var listaDeimoveis = await _consultarimovel.ListarTodosImoveis();

            if (listaDeimoveis == null)
                return null;

            var listaDeimoveisViewModel = ImovelFactory.MapearListaImovelViewModel(listaDeimoveis);
            return listaDeimoveisViewModel;
        }
    }
}
