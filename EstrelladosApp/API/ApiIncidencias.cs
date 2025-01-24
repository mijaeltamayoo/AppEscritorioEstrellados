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
        private readonly string apiUrl;

        public ApiIncidencias()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string endpoint = ConfigurationManager.AppSettings["IncidenciasEndpoint"];
            apiUrl = $"{baseUrl}{endpoint}";

            // Mostrar la URL generada
            Console.WriteLine($"URL generada para la API de incidencias: {apiUrl}");
        }

        public async Task<List<IncidenciaDTO>> GetIncidenciasAsync()
        {
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
    }
}
