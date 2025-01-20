namespace EstrelladosApp.DTOs
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public RolDTO Rol { get; set; }
    }

    public class RolDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
    }
}
