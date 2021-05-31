using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class CriarFornecedorViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [DisplayName("Capital Disponível")]
        [DataType(DataType.Currency, ErrorMessage = "Valor inválido!")]
        [Range(500, double.MaxValue, ErrorMessage = "Maior ou igual a {1}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal Capital { get; set; }
    }
}