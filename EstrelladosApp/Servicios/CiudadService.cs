using EstrelladosApp.API;
using EstrelladosApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstrelladosApp.Servicios
{
    internal class CiudadService
    {
        private readonly ApiCiudades _apiCiudades;

        public CiudadService()
        {
            _apiCiudades = new ApiCiudades();
        }

        public async Task<List<CiudadDTO>> ObtenerCiudadesAsync()
        {
            return await _apiCiudades.GetCiudadesAsync();
        }
    }
}
