using Microsoft.AspNetCore.Identity;

namespace EO.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string ChavePix { get; set; }
    }
}