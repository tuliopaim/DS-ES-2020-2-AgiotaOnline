using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class AlterarSenhaViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)] 
        [Display(Name = "Senha")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}