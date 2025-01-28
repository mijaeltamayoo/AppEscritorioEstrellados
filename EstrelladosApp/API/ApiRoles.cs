using EstrelladosApp.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstrelladosApp.API
{
    public class ApiRoles
    {
        private readonly string apiUrl;

        public ApiRoles()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string rolesEndpoint = ConfigurationManager.AppSettings["RolesEndpoint"];
            apiUrl = $"{baseUrl}{rolesEndpoint}";

            // Mostrar apiUrl por consola
            Console.WriteLine($"URL generada para la API de roles: {apiUrl}");
        }

        public async Task<List<RolDTO>> GetRolesAsync()
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

                        // Deserializar ignorando la propiedad "usuarios"
                        var roles = JArray.Parse(jsonResponse)
                            .Select(role => new RolDTO
                            {
                                Id = (int)role["id"],
                                Name = (string)role["name"]
                            })
                            .ToList();

                        return roles;
                    }
                    else
                    {
                        Console.WriteLine($"Error al conectar con la API: {response.StatusCode}");
                        return new List<RolDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<RolDTO>();
            }
        }
    }
}

