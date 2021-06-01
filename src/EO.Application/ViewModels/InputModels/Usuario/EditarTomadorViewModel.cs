using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class EditarTomadorViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [DisplayName("Renda Mensal")]
        [DataType(DataType.Currency)]
        [Range(500, double.MaxValue, ErrorMessage = "Maior ou igual a {1}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal RendaMensal { get; set; }

        public CriarEnderecoViewModel Endereco { get; set; }
    }
}