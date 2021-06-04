using System;
using EO.Domain.Enums;

namespace EO.Domain.Entities
{
    public class SolicitacaoEmprestimo : Entidade
    {
        public SolicitacaoEmprestimo(decimal valor, int parcelas)
        {
            Valor = valor;
            Parcelas = parcelas;
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
    }
}