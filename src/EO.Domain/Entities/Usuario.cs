using EO.Domain.Core;
using EO.Domain.Enums;
using EO.Domain.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace EO.Domain.Entities
{
    public class Usuario : IdentityUser<int>
    {
        private readonly UsuarioValidator _validador;

        protected Usuario()
        {
            _validador = new UsuarioValidator();
        }

        public Usuario(string nome, string cpf, string telefone, string chavePix, TipoUsuario tipo)
        {
            Nome = nome;
            Cpf = Helper.SemFormatacao(cpf);
            Telefone = Helper.SemFormatacao(telefone);
            ChavePix = Helper.SemFormatacao(chavePix);
            Tipo = tipo;

            _validador = new UsuarioValidator();
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

        public ValidationResult Validar() => _validador.Validate(this);

        public bool EhValido() => Validar().IsValid;
    }
}