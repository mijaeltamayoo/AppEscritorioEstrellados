using EstrelladosApp.DTOs;
using EstrelladosApp.API;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
