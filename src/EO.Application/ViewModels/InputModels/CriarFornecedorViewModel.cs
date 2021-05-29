using System.ComponentModel;

namespace EO.Application.ViewModels.InputModels
{
    public class CriarFornecedorViewModel
    {
        [DisplayName("Capital Disponível")]
        public decimal Capital { get; set; }
    }
}