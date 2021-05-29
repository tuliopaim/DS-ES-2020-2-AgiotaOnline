using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }
}