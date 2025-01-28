using EstrelladosApp.API;
using EstrelladosApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstrelladosApp.Servicios
{
    internal class ProvinciaService
    {
        private readonly ApiProvincias _apiProvincias;

        public ProvinciaService()
        {
            _apiProvincias = new ApiProvincias();
        }

        public async Task<List<ProvinciaDTO>> ObtenerProvinciasAsync()
        {
            return await _apiProvincias.GetProvinciasAsync();
        }
    }
}
