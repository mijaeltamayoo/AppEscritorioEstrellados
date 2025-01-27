using EstrelladosApp.API;
using EstrelladosApp.DTOs;
using System;
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
        public async Task<bool> RegistrarIncidencia(IncidenciafkDTO nuevaIncidencia)
        {

            return await _apiIncidencias.PostCrearIncidenciaAsync(nuevaIncidencia);
        }

        internal async Task<bool> deleteIncidencia(IncidenciafkDTO nuevaIncidencia)
        {
            return await _apiIncidencias.DeleteIncidenciaAsync(nuevaIncidencia);
        }
    }
}
