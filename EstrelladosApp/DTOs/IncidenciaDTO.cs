using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrelladosApp.DTOs
{
    public class IncidenciaDTO
    {
        public int Id { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Causa { get; set; }
        public string NivelIncidencia { get; set; }
        public string Carretera { get; set; }
        public DateTime FechaInicio { get; set; }
        public CiudadDTO Ciudad { get; set; }
        public ProvinciaDTO Provincia { get; set; }
        public RegionDTO Region { get; set; }
        public TipoIncidenciaDTO TipoIncidencia { get; set; }
    }

}
