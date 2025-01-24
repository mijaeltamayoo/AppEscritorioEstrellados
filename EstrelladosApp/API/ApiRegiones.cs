using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.API
{
    public class ApiRegiones
    {
        private readonly string apiUrl;

        public ApiRegiones()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string endpoint = ConfigurationManager.AppSettings["RegionEndpoint"];
            apiUrl = $"{baseUrl}{endpoint}";

            Console.WriteLine($"URL generada para la API de regiones: {apiUrl}");
        }

        public async Task<List<RegionDTO>> GetRegionesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var regiones = JsonConvert.DeserializeObject<List<RegionDTO>>(jsonResponse);
                        return regiones ?? new List<RegionDTO>();
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                        return new List<RegionDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<RegionDTO>();
            }
        }
    }
}
