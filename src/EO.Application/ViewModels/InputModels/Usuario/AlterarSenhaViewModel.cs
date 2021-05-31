using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)] 
        [Display(Name = "Senha")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}