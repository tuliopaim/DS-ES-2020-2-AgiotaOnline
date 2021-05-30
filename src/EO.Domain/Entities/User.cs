using EO.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace EO.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        protected User()
        {
        }

        public User(string nome, string cpf, string telefone, string chavePix, TipoUsuario tipo)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            ChavePix = chavePix;
            Tipo = tipo;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }
        public string ChavePix { get; private set; }
        public TipoUsuario Tipo { get; private set; }

        public void AlterarTelefone(string novoTelefone)
        {
            Telefone = novoTelefone;
        }

        public void AlterarChavePix(string novaChavePix)
        {
            ChavePix = novaChavePix;
        }
    }
}