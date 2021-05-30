﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EO.Domain.Enums;

namespace EO.Application.ViewModels.InputModels.Usuario
{
    public class EditarUsuarioViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required]
        [DisplayName("Chave Pix")]
        public string ChavePix { get; set; }

        public TipoUsuario Tipo { get; set; }

        public EditarTomadorViewModel Tomador { get; set; }

        public EditarFornecedorViewModel Fornecedor { get; set; }
    }
}