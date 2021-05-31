using System.ComponentModel;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class EditarTomadorViewModel
    {
        public int Id { get; set; }

        [DisplayName("Renda Mensal")]
        public decimal RendaMensal { get; set; }

        public CriarEnderecoViewModel Endereco { get; set; }
    }
}