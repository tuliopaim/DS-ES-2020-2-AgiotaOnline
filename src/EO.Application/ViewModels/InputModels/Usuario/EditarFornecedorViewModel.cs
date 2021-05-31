﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class EditarFornecedorViewModel
    {
        [Required(ErrorMessage = "{0} obrigatório(a)")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Capital Disponível")]
        [Range(500, double.MaxValue)]
        public decimal Capital { get; set; }
    }
}