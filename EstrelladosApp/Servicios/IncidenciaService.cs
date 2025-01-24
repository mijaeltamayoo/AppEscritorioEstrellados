using EstrelladosApp.API;
using EstrelladosApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstrelladosApp.Servicios
{
    internal class IncidenciaService
    {
        private readonly ApiIncidencias _apiIncidencias;

        public IncidenciaService()
        {
            _apiIncidencias = new ApiIncidencias();
        }

        public async Task<List<IncidenciaDTO>> ObtenerIncidenciasAsync()
        {
            return await _apiIncidencias.GetIncidenciasAsync();
        }
    }
}
