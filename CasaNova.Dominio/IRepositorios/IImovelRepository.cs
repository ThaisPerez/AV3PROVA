using CasaNova.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaNova.Dominio.IRepositorios
{
    public interface IImovelRepository
    {
        Task Criar(Imovel imovel);
        Task Alterar(Imovel imovel);
        Task Excluir(int id);
        Task<Imovel> BuscarPorId(int id);
        Task<Imovel> BuscarBairro(string bairro);
        Task<IEnumerable<Imovel>> ListarCidade(string cidade);
        Task<IEnumerable<Imovel>> ListarTodosImoveis();
    }
}
