using EstrelladosApp.API;
using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.Servicios
{
    internal class RolService
    {
        private readonly ApiRoles _apiRoles;

        public RolService()
        {
            _apiRoles = new ApiRoles();
        }

        public async Task<List<RolDTO>> ObtenerRolesAsync()
        {
            return await _apiRoles.GetRolesAsync();
        }
    }
}