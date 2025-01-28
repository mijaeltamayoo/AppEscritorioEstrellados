using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrelladosApp.DTOs
{
    public class IncidenciafkDTO
    {
        public int id { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string causa { get; set; }
        public string nivelIncidencia { get; set; }
        public string carretera { get; set; }
        public DateTime fechaInicio { get; set; }
        public long idCiudad { get; set; }
        public long idRegion { get; set; }
        public long idTipoIncidencia { get; set; }
    }

}
