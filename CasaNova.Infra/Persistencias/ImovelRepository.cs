using CasaNova.Dominio.Entidades;
using CasaNova.Dominio.IRepositorios;
using CasaNova.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaNova.Infra.Persistencias
{
    public class IMovelRepository : IImovelRepository
    {
        private readonly DataContext _dataContext;

        public IMovelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Criar(Imovel imovel)
        {
            _dataContext.Imoveis.Add(imovel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Alterar(Imovel imovel)
        {
            _dataContext.Update(imovel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var imovel = await _dataContext.Imoveis.FirstOrDefaultAsync(x => x.Id == id);

            _dataContext.Imoveis.Remove(imovel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Imovel> BuscarPorId(int id)
        {
            return await _dataContext.Imoveis.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Imovel> BuscarBairro(string bairro)
        {
            return await _dataContext.Imoveis.FirstOrDefaultAsync(x => x.Bairro == bairro);
        }

        public async Task<IEnumerable<Imovel>> ListarCidade(string cidade)
        {
            return await _dataContext.Imoveis.AsNoTracking().Where(x => x.Cidade == cidade).ToListAsync();
        }

        public async Task<IEnumerable<Imovel>> ListarTodosImoveis()
        {
            return await _dataContext.Imoveis.AsNoTracking().ToListAsync();
        }
    }
}
