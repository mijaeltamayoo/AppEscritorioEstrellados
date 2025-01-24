using EstrelladosApp.API;
using EstrelladosApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstrelladosApp.Servicios
{
    internal class RegionService
    {
        private readonly ApiRegiones _apiRegiones;

        public RegionService()
        {
            _apiRegiones = new ApiRegiones();
        }

        public async Task<List<RegionDTO>> ObtenerRegionesAsync()
        {
            return await _apiRegiones.GetRegionesAsync();
        }
    }
}
