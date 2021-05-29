using System.ComponentModel;

namespace EO.Application.ViewModels.InputModels
{
    public class CriarTomadorViewModel
    {
        [DisplayName("Renda Mensal")]
        public decimal RendaMensal { get; set; }

        public CriarEnderecoViewModel Endereco { get; set; }
    }
}