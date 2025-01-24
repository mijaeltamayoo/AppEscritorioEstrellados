using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.API
{
    public class ApiCiudades
    {
        private readonly string apiUrl;

        public ApiCiudades()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string endpoint = ConfigurationManager.AppSettings["CiudadEndpoint"];
            apiUrl = $"{baseUrl}{endpoint}";

            Console.WriteLine($"URL generada para la API de ciudades: {apiUrl}");
        }

        public async Task<List<CiudadDTO>> GetCiudadesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(jsonResponse);
                        return ciudades ?? new List<CiudadDTO>();
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                        return new List<CiudadDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<CiudadDTO>();
            }
        }
    }
}
