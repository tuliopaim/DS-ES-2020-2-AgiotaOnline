using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar de mim?")]
        public bool RememberMe { get; set; }
    }
}