using System.ComponentModel.DataAnnotations;

namespace CasaNova.Api.ViewModels
{
    public class ImovelViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cidade { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Bairro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string QtdQuartos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Valor { get; set; }
    }
}
