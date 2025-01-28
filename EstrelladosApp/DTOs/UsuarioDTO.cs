using Newtonsoft.Json;

namespace EstrelladosApp.DTOs
{
    public class UsuarioDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("contraseña")]
        public string Contraseña { get; set; }

        [JsonProperty("rol")]
        public RolDTO Rol { get; set; }
    }

    public class RolDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nombre")]
        public string Name { get; set; }
    }
}
