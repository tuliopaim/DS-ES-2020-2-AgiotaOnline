using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EO.Domain.Enums;

namespace EO.Application.ViewModels.InputModels
{
    public class CriarUsuarioViewModel
    {
        public CriarUsuarioViewModel()
        {
        }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação não conferem.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required]
        [Display(Name = "Chave Pix")]
        public string ChavePix { get; set; }

        [DisplayName("Tipo de Usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        public CriarTomadorViewModel Tomador { get; set; }

        public CriarFornecedorViewModel Fornecedor { get; set; }
    }
}