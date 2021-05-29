using System.ComponentModel;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class EditarFornecedorViewModel
    {

        [DisplayName("Capital Disponível")]
        public decimal Capital { get; set; }
    }
}