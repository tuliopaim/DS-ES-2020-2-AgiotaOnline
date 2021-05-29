using System.ComponentModel;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class CriarFornecedorViewModel
    {
        [DisplayName("Capital Disponível")]
        public decimal Capital { get; set; }
    }
}