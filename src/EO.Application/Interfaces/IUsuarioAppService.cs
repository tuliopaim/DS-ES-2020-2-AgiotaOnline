﻿using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.Usuario;

namespace EO.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<bool> AdicionarUsuario(CriarUsuarioViewModel model);

        Task<EditarUsuarioViewModel> ObterUsuarioParaEdicao(int id);

        Task EditarUsuario(EditarUsuarioViewModel model);
    }
}