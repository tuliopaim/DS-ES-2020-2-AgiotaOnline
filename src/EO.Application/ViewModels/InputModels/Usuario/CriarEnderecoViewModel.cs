using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class CriarEnderecoViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(11, ErrorMessage = "A {0} deve ter {1} caracteres.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(250, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 3)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(250, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 3)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(250, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 3)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 3)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(25, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(25, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 2)]
        public string Pais { get; set; }
    }
}