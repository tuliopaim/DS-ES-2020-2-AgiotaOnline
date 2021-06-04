using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.SolicitacaoEmprestimo
{
    public class CriarSolicitacaoEmprestimo
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [DisplayName("Valor Solicitado")]
        [DataType(DataType.Currency)]
        [Range(1, double.MaxValue, ErrorMessage = "Maior ou igual a {1}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal Valor { get; set; }


        [Required(ErrorMessage = "{0} obrigatório(a)")]
        [DisplayName("Quantidade de Parcelas")]
        [Range(1, 24, ErrorMessage = "Entre {1} e {2}")]
        public int Parcelas { get; set; }
    }
}