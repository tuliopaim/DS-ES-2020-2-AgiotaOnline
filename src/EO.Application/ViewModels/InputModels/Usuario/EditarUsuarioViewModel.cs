using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EO.Domain.Enums;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class EditarUsuarioViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(16, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 11)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 5)]
        [DisplayName("Chave Pix")]
        public string ChavePix { get; set; }

        public TipoUsuario Tipo { get; set; }

        public EditarTomadorViewModel Tomador { get; set; }

        public EditarFornecedorViewModel Fornecedor { get; set; }
    }
}