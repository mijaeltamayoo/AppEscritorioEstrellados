using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.API
{
    public class ApiTiposIncidencia
    {
        private readonly string apiUrl;

        public ApiTiposIncidencia()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string endpoint = ConfigurationManager.AppSettings["TiposIncidenciasEndpoint"];
            apiUrl = $"{baseUrl}{endpoint}";

            Console.WriteLine($"URL generada para la API de tipos de incidencia: {apiUrl}");
        }

        public async Task<List<TipoIncidenciaDTO>> GetTiposIncidenciaAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var tiposIncidencia = JsonConvert.DeserializeObject<List<TipoIncidenciaDTO>>(jsonResponse);
                        return tiposIncidencia ?? new List<TipoIncidenciaDTO>();
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                        return new List<TipoIncidenciaDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<TipoIncidenciaDTO>();
            }
        }
    }
}
