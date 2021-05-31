using System.ComponentModel;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class EditarFornecedorViewModel
    {
        public int Id { get; set; }

        [DisplayName("Capital Disponível")]
        public decimal Capital { get; set; }
    }
}