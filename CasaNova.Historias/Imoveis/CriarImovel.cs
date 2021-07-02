using CasaNova.Dominio.Entidades;
using CasaNova.Dominio.IRepositorios;
using System.Threading.Tasks;

namespace CasaNova.Historias.Imoveis
{
    public class CriarImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public CriarImovel(IImovelRepository ImovelRepository)
        {
            _imovelRepository = ImovelRepository;
        }

        public async Task Executar(Imovel imovel)
        {
            await _imovelRepository.Criar(imovel);
        }
    }
}
