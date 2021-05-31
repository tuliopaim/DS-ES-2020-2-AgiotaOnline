using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class CriarFornecedorViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [DisplayName("Capital Disponível")]
        [Range(500, double.MaxValue)]
        public decimal Capital { get; set; }
    }
}