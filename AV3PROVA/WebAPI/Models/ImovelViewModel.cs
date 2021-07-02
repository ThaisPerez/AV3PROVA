using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class ImovelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Cidade { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Bairro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Qtquartos { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Valor { get; set; }
    }
}
