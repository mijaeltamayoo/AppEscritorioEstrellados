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
        string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

        public ApiUsuarios(){}

        public async Task<List<UsuarioDTO>> GetUsuariosAsync()
        {
            string apiUrl = $"{baseUrl}{ConfigurationManager.AppSettings["UsuariosEndpoint"]}";
            Console.WriteLine($"URL generada para la API de usuarios: {apiUrl}");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    Console.WriteLine($"Estado de la respuesta: {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

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
        internal async Task<bool> PostRegistrarUsuarioAsync(UsuarioDTO nuevoUsuario)
        {
            string apiUrl = $"{baseUrl}{ConfigurationManager.AppSettings["RegisterEndpoint"]}";
            Console.WriteLine($"URL generada para la API de usuarios: {apiUrl}");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Crear el objeto sin el rol
                    var usuarioSinRol = new UsuarioSinRolDTO
                    {
                        Nombre = nuevoUsuario.Nombre,
                        Correo = nuevoUsuario.Correo,
                        Contraseña = nuevoUsuario.Contraseña
                    };

                    // Serializar el objeto sin rol
                    string jsonBody = JsonConvert.SerializeObject(usuarioSinRol);
                    StringContent content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                    // Mostrar el JSON enviado por consola
                    Console.WriteLine($"JSON enviado: {jsonBody}");

                    // Enviar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Mostrar el estado de la respuesta
                    Console.WriteLine($"Estado de la respuesta: {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta del servidor
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Respuesta JSON recibida: {jsonResponse}");

                        return true; // Indicar que la operación fue exitosa
                    }
                    else
                    {
                        Console.WriteLine($"Error al registrar usuario: {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return false;
            }
        }
        internal async Task<bool> DeleteUsuarioAsync(long id)
        {
            string apiUrl = $"{baseUrl}{ConfigurationManager.AppSettings["UsuariosEndpoint"]}/{id}";
            Console.WriteLine($"URL generada para la eliminación del usuario: {apiUrl}");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Enviar la solicitud DELETE
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    // Mostrar el estado de la respuesta
                    Console.WriteLine($"Estado de la respuesta: {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta del servidor
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Respuesta JSON recibida: {jsonResponse}");

                        return true; // Indicar que la operación fue exitosa
                    }
                    else
                    {
                        Console.WriteLine($"Error al eliminar usuario: {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return false;
            }
        }

        internal async Task<bool> ActualizarUsuario(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
