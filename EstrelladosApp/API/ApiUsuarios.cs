using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.API
{
    internal class ApiUsuarios
    {
        private readonly string apiUrl;

        public ApiUsuarios()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string usuariosEndpoint = ConfigurationManager.AppSettings["UsuariosEndpoint"];
            apiUrl = $"{baseUrl}{usuariosEndpoint}";

            // Mostrar apiUrl por consola
            Console.WriteLine($"URL generada para la API de usuarios: {apiUrl}");
        }

        public async Task<List<UsuarioDTO>> GetUsuariosAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Mostrar el estado de la respuesta por consola
                    Console.WriteLine($"Estado de la respuesta: {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Mostrar el contenido del JSON recibido
                        Console.WriteLine($"Respuesta JSON recibida: {jsonResponse}");

                        return JsonConvert.DeserializeObject<List<UsuarioDTO>>(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                        return new List<UsuarioDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<UsuarioDTO>();
            }
        }
    }
}
