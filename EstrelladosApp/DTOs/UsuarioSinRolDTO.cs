using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrelladosApp.DTOs
{
    public class UsuarioSinRolDTO
    {
        

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("contraseña")]
        public string Contraseña { get; set; }
    }

}
