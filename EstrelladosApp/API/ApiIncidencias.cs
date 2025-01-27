using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.API
{
    public class ApiIncidencias
    {
        private readonly string baseUrl;

        public ApiIncidencias()
        {
            baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            //apiUrl = $"{baseUrl}{endpoint}";

        }

        public async Task<List<IncidenciaDTO>> GetIncidenciasAsync()
        {
            string apiUrl = $"{baseUrl}{ConfigurationManager.AppSettings["IncidenciasEndpoint"]}";
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

                        var incidencias = JsonConvert.DeserializeObject<List<IncidenciaDTO>>(jsonResponse);
                        return incidencias ?? new List<IncidenciaDTO>();
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                        return new List<IncidenciaDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<IncidenciaDTO>();
            }
        }

        internal async Task<bool> DeleteIncidenciaAsync(IncidenciafkDTO incidencia)
        {
            string apiUrl = $"{baseUrl}{ConfigurationManager.AppSettings["EliminarIncidenciaEndpoint"]}";
            Console.WriteLine($"URL generada para eliminar incidencia: {apiUrl}");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Serializar el objeto incidencia
                    string jsonBody = JsonConvert.SerializeObject(incidencia);
                    StringContent content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                    // Crear una solicitud HTTP personalizada
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(apiUrl),
                        Content = content
                    };

                    // Enviar la solicitud DELETE
                    HttpResponseMessage response = await client.SendAsync(request);

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
                        Console.WriteLine($"Error al eliminar incidencia: {response.StatusCode}");
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


        internal async Task<bool> PostCrearIncidenciaAsync(IncidenciafkDTO nuevaIncidencia)
        {
            string apiUrl = $"{baseUrl}{ConfigurationManager.AppSettings["CrearIncidenciaEndpoint"]}";
            Console.WriteLine($"URL generada para la API de usuarios: {apiUrl}");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    

                    // Serializar el objeto sin rol
                    string jsonBody = JsonConvert.SerializeObject(nuevaIncidencia);
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
    }
}
