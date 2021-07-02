using CasaNova.Dominio.Entidades;
using CasaNova.Dominio.IRepositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaNova.Historias.Imoveis
{
    public class ConsultarImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public ConsultarImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public async Task<Imovel> BuscarPorId(int id)
        {
            return await _imovelRepository.BuscarPorId(id);
        }

        public async Task<Imovel> BuscarBairro(string bairro)
        {
            return await _imovelRepository.BuscarBairro(bairro);
        }

        public async Task<IEnumerable<Imovel>> ListarCidade(string cidade)
        {
            return await _imovelRepository.ListarCidade(cidade);
        }

        public async Task<IEnumerable<Imovel>> ListarTodosImoveis()
        {
            return await _imovelRepository.ListarTodosImoveis();
        }
    }
}
