using EstrelladosApp.DTOs;
using EstrelladosApp.API;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;

namespace EstrelladosApp.Servicios
{
    internal class UsuarioService
    {
        private readonly ApiUsuarios _apiUsuarios;

        public UsuarioService()
        {
            _apiUsuarios = new ApiUsuarios();
        }

        public async Task<List<UsuarioDTO>> ObtenerUsuariosAsync()
        {
            return await _apiUsuarios.GetUsuariosAsync();
        }
        public async Task<bool> RegistrarUsuario(UsuarioDTO nuevoUsuario)
        {
            
            return await _apiUsuarios.PostRegistrarUsuarioAsync(nuevoUsuario);
        }
        public async Task<bool> BorrarUsuario(long id)
        {
            return await _apiUsuarios.DeleteUsuarioAsync(id);
        }

        internal async Task<bool> ActualizarUsuario(UsuarioDTO usuario)
        {
            return await _apiUsuarios.ActualizarUsuario(usuario);
    }
    }
}
