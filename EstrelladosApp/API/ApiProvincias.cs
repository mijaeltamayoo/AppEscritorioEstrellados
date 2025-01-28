using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.API
{
    public class ApiProvincias
    {
        private readonly string apiUrl;

        public ApiProvincias()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string endpoint = ConfigurationManager.AppSettings["ProvinciaEndpoint"];
            apiUrl = $"{baseUrl}{endpoint}";

            Console.WriteLine($"URL generada para la API de provincias: {apiUrl}");
        }

        public async Task<List<ProvinciaDTO>> GetProvinciasAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var provincias = JsonConvert.DeserializeObject<List<ProvinciaDTO>>(jsonResponse);
                        return provincias ?? new List<ProvinciaDTO>();
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                        return new List<ProvinciaDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<ProvinciaDTO>();
            }
        }
    }
}
