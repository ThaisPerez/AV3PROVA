using CasaNova.Dominio.Entidades;
using CasaNova.Dominio.IRepositorios;
using System.Threading.Tasks;

namespace CasaNova.Historias.Imoveis
{
    public class AlterarImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public AlterarImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }


        public async Task Executar(int id, Imovel imovel)
        {
            var dadosDoImovel = await _imovelRepository.BuscarPorId(id);

            dadosDoImovel.AtualizarDados(imovel.Cidade, imovel.Bairro, imovel.Logradouro, imovel.QtdQuartos, imovel.Valor);

            await _imovelRepository.Alterar(dadosDoImovel);
        }
    }
}
