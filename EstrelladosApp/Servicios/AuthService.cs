using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EstrelladosApp.Servicios
{
    public class AuthService
    {
        private readonly string loginApiUrl;

        public AuthService()
        {
            // Configuración de la URL del login desde appSettings
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string loginEndpoint = ConfigurationManager.AppSettings["LoginEndpoint"];
            loginApiUrl = $"{baseUrl}{loginEndpoint}";
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //password =Utils.MD5(password);
                    // Mostrar la contraseña hasheada por consola
                    
                    // Crear la petición JSON
                    var loginRequest = new { nombre = username, contraseña = password };
                    var jsonContent = JsonConvert.SerializeObject(loginRequest);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(loginApiUrl, httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"jsonResponse: {jsonResponse}");
                        return JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al enviar la solicitud: {ex.Message}");
                    throw;
                }
            }
        }
    }

    public class LoginResponse
    {
        public string Rol { get; set; }
    }
}
