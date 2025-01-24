using EstrelladosApp.API;
using EstrelladosApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstrelladosApp.Servicios
{
    internal class TipoIncidenciaService
    {
        private readonly ApiTiposIncidencia _apiTiposIncidencia;

        public TipoIncidenciaService()
        {
            _apiTiposIncidencia = new ApiTiposIncidencia();
        }

        public async Task<List<TipoIncidenciaDTO>> ObtenerTiposIncidenciaAsync()
        {
            return await _apiTiposIncidencia.GetTiposIncidenciaAsync();
        }
    }
}
