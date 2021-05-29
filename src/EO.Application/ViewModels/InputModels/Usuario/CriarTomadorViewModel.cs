using System.ComponentModel;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class CriarTomadorViewModel
    {
        [DisplayName("Renda Mensal")]
        public decimal RendaMensal { get; set; }

        public CriarEnderecoViewModel Endereco { get; set; }
    }
}