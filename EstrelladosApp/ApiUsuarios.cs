using System;
using Newtonsoft.Json; 
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EstrelladosApp
{
    internal class ApiUsuarios
    {
        private string apiUrl = "http://localhost:8080/api/usuarios";
        /// <summary>
        /// call http://localhost:8080/api/usuarios
        /// </summary>
        /// <returns>a List<UsuarioDTO></returns>
        public async Task<List<UsuarioDTO>> GetUsuariosAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
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
