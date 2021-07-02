using CasaNova.Api.ViewModels;
using CasaNova.Dominio.Entidades;
using System.Collections.Generic;

namespace CasaNova.Api.Factories
{
    public class ImovelFactory
    {
        public static Imovel MapearImovel(ImovelViewModel viewModel)
        {
            return new Imovel(viewModel.Cidade,
                viewModel.Bairro,
                viewModel.Logradouro,
                viewModel.QtdQuartos,
                viewModel.Valor);
        }

        public static ImovelViewModel MapearImovelViewModel(Imovel imovel)
        {
            return new ImovelViewModel
            {
                Id = imovel.Id,
                Cidade = imovel.Cidade,
                Bairro = imovel.Bairro,
                Logradouro = imovel.Logradouro,
                QtdQuartos = imovel.QtdQuartos,
                Valor = imovel.Valor
            };
        }

        public static IEnumerable<ImovelViewModel> MapearListaImovelViewModel(IEnumerable<Imovel> listaDeImoveis)
        {
            var listaDeImovelViewModel = new List<ImovelViewModel>();

            ImovelViewModel imovelViewModel;

            foreach (var imovel in listaDeImoveis)
            {
                imovelViewModel = new ImovelViewModel
                {
                    Id = imovel.Id,
                    Cidade = imovel.Cidade,
                    Bairro = imovel.Bairro,
                    Logradouro = imovel.Logradouro,
                    QtdQuartos = imovel.QtdQuartos,
                    Valor = imovel.Valor
                };

                listaDeImovelViewModel.Add(imovelViewModel);
            }

            return listaDeImovelViewModel;
        }
    }
}
