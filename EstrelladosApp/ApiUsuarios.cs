using System;
using Newtonsoft.Json; 
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EstrelladosApp
{
    internal class ApiUsuarios
    {
        private string apiUrl = "http://localhost:8080/api/usuarios";

        public async Task GetUsuariosAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        List<UsuarioDTO> usuarios = JsonConvert.DeserializeObject<List<UsuarioDTO>>(jsonResponse);

                        foreach (var usuario in usuarios)
                        {
                            Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Nombre}, Correo: {usuario.Correo}, Rol: {usuario.Rol}, Contraseña: {usuario.Contraseña}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
