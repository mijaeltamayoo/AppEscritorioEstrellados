using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;

namespace EstrelladosApp
{
    public partial class Form1 : Form
    {
        private readonly string loginApiUrl;

        public Form1()
        {
            InitializeComponent();
            // Configuración de la URL del login desde appSettings
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string loginEndpoint = ConfigurationManager.AppSettings["LoginEndpoint"];
            loginApiUrl = $"{baseUrl}{loginEndpoint}";
            Console.WriteLine($"URL generada para login: {loginApiUrl}");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private async void entrar_Click(object sender, EventArgs e)
        {
            string usuario = text_user.Text.Trim();
            string password = text_password.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, complete ambos campos.");
                return;
            }

            try
            {
                var loginResult = await LoginAsync(usuario, password);

                if (loginResult != null)
                {
                    if (loginResult.Rol == "administrador")
                    {
                        // Abrir la ventana principal si el rol es administrador
                        Principal principal = new Principal();
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Acceso denegado. No tiene permisos suficientes.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error durante el login: {ex.Message}");
                
            }
        }

        private async Task<LoginResponse> LoginAsync(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Crear la petición JSON
                    var loginRequest = new { nombre = username, contraseña = password };
                    var jsonContent = JsonConvert.SerializeObject(loginRequest);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(loginApiUrl, httpContent);

                    Console.WriteLine($"Estado de la respuesta:{loginApiUrl}   *   {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Respuesta JSON: {jsonResponse}");
                        return JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error en el servidor: {errorResponse}");
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

        public class LoginResponse
        {
            public string Rol { get; set; }
        }

        // Métodos para manejo visual de los campos de texto
        private void text_user_Enter(object sender, EventArgs e)
        {
            if (text_user.Text == "USUARIO")
            {
                text_user.Text = "";
                text_user.ForeColor = Color.LightGray;
            }
        }

        private void text_password_Enter(object sender, EventArgs e)
        {
            if (text_password.Text == "CONTRASEÑA")
            {
                text_password.Text = "";
                text_password.ForeColor = Color.LightGray;
            }
        }

        private void text_user_Leave(object sender, EventArgs e)
        {
            if (text_user.Text == "")
            {
                text_user.Text = "USUARIO";
                text_user.ForeColor = Color.DimGray;
            }
        }

        private void text_password_Leave(object sender, EventArgs e)
        {
            if (text_password.Text == "")
            {
                text_password.Text = "CONTRASEÑA";
                text_password.ForeColor = Color.DimGray;
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
