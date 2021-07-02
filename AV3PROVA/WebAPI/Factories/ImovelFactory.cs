using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Factories
{
    public static class ImovelFactory
    {
        public static Imovel MapearImovel(ImovelViewModel imovelViewModel)
        {
            return new Imovel(
                imovelViewModel.Cidade,
                imovelViewModel.Bairro,
                imovelViewModel.Logradouro,
                imovelViewModel.Qtquartos,
                imovelViewModel.Valor);
        }

        public static ImovelViewModel MapearImovelViewModel(Imovel imovel)
        {
            return new ImovelViewModel
            {
                Id = imovel.Id,
                Cidade = imovel.Cidade,
                Bairro = imovel.Bairro,
                Logradouro = imovel.Logradouro,
                Qtquartos = imovel.Qtquartos,
                Valor = imovel.Valor
            };
        }

        public static IEnumerable<ImovelViewModel> MapearListaImovelViewModel(IEnumerable<Imovel> listaDeImoveis)
        {
            var listaDeImoveisViewModel = new List<ImovelViewModel>();

            ImovelViewModel imovelViewModel;

            foreach (var imovel in listaDeImoveis)
            {
                imovelViewModel = new ImovelViewModel
                {
                    Id = imovel.Id,
                    Cidade = imovel.Cidade,
                    Bairro = imovel.Bairro,
                    Logradouro = imovel.Logradouro,
                    Qtquartos = imovel.Qtquartos,
                    Valor = imovel.Valor
                };

                listaDeImoveisViewModel.Add(imovelViewModel);
            }

            return listaDeImoveisViewModel;
        }
    }
}
