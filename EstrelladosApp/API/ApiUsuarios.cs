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
        /*error y la peticion 
         
         "Usuario actualizado: 5nullnullnull" "@PutMapping("/usuarios/{id}")
    public ResponseEntity<UsuarioDTO> actualizarUsuario(@PathVariable Long id, @RequestBody UsuarioDTO usuarioDTO) {
        Optional<Usuario> usuario_nuevo = usuarioRepositorio.findById(id);
        
        if (usuario_nuevo.isEmpty()) {
            return ResponseEntity.notFound().build(); 
        }

        Usuario usuario = usuario_nuevo.get();
        usuario.setNombre(usuarioDTO.getNombre());
        usuario.setCorreo(usuarioDTO.getCorreo());
        usuario.setContraseña(usuarioDTO.getContraseña());


        Usuario usuario_updated = usuarioRepositorio.save(usuario);

        UsuarioDTO updatedUsuarioDTO = new UsuarioDTO(
            usuario_updated.getId(),
            usuario_updated.getNombre(),
            usuario_updated.getCorreo(),
            usuario_updated.getContraseña(),
            new RolPrivateDTO(usuario_updated.getRol().getId(),usuario_updated.getRol().getName())
            );
            System.out.println("Usuario actualizado: " + usuario_updated.getId()+
            usuario_updated.getNombre()+
            usuario_updated.getCorreo()+
            usuario_updated.getContraseña());
        return ResponseEntity.ok(updatedUsuarioDTO); 
    }" "URL generada para la actualización del usuario: http://10.10.13.251:8080/usuarios/4
JSON enviado: {"Id":4,"Nombre":"user","Correo":"user1@estrella2.com","Contraseña":"9250e222c4c71f0c58d4c54b50a880a312e9f9fed55d5c3aa0b0e860ded99165","Rol":{"Id":2,"Name":null}}
peticion JSON recibida: System.Net.Http.StringContent
Estado de la respuesta: OK
Respuesta JSON recibida: {"id":4,"nombre":null,"correo":null,"contraseña":null,"rol":{"id":2,"nombre":"usuario"}}
URL generada para la API de usuarios: http://10.10.13.251:8080/usuarios
Estado de la respuesta: OK" 
         */
        internal async Task<bool> ActualizarUsuario(UsuarioDTO usuario)
        {
            string apiUrl = $"{baseUrl}{ConfigurationManager.AppSettings["UsuariosEndpoint"]}/{usuario.Id}";
            Console.WriteLine($"URL generada para la actualización del usuario: {apiUrl}");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Serializar el objeto UsuarioDTO a JSON
                    string jsonBody = JsonConvert.SerializeObject(usuario);
                    StringContent content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                    // Mostrar el JSON enviado por consola
                    Console.WriteLine($"JSON enviado: {jsonBody}");

                    // Enviar la solicitud PUT
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);
                    Console.WriteLine($"peticion JSON recibida: {content}");
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
                        // Leer el cuerpo del error para más detalles
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error al actualizar usuario: {response.StatusCode}, Detalles: {errorResponse}");
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
