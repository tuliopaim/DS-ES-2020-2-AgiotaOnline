using System;
using EO.Domain.Enums;
using EO.Domain.Validations;
using FluentValidation.Results;

namespace EO.Domain.Entities
{
    public class SolicitacaoEmprestimo : Entidade
    {
        private readonly SolicitacaoEmprestimoValidator _validador;

        protected SolicitacaoEmprestimo()
        {
            _validador = new SolicitacaoEmprestimoValidator();
        }

        public SolicitacaoEmprestimo(decimal valor, int parcelas, int tomadorId) : this()
        {
            Valor = valor;
            Parcelas = parcelas;
            TomadorId = tomadorId;
            Status = StatusSolicitacao.Pendente;
        }

        public decimal Valor { get; private set; }  
        public int Parcelas { get; private set; }  
        public StatusSolicitacao Status { get; private set; }

        public int TomadorId { get; set; }

        public void ConcluirSolicitacao()
        {
            Status = StatusSolicitacao.Concluida;
        }

        public void CancelarSolicitacao()
        {
            Status = StatusSolicitacao.Cancelada;
        }

        public ValidationResult Validar() => _validador.Validate(this);

        public override bool EhValido() => Validar().IsValid;
    }
}