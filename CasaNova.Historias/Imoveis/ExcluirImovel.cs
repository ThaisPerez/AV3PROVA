using CasaNova.Dominio.IRepositorios;
using System.Threading.Tasks;

namespace CasaNova.Historias.Imoveis
{
    public class ExcluirImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public ExcluirImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public async Task Executar(int id)
        {
            await _imovelRepository.Excluir(id);
        }
    }
}
