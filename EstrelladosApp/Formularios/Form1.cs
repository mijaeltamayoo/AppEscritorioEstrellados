using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EstrelladosApp.API;

namespace EstrelladosApp
{
    public partial class Form1 : Form
    {
        private ApiUsuarios api = new ApiUsuarios();

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private async void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#072942");
            text_user.BackColor = System.Drawing.ColorTranslator.FromHtml("#072942");
            text_password.BackColor = System.Drawing.ColorTranslator.FromHtml("#072942");
            await api.GetUsuariosAsync();
        }

        private async void entrar_Click(object sender, EventArgs e)
        {
            string usuario = text_user.Text;
            string password = text_password.Text;

            try
            {
                var loginResult = await LoginAsync(usuario, password);

                if (loginResult != null)
                {
                    if (loginResult.Rol == "administrador")
                    {
                        Principal principal = new Principal();
                        principal.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private async Task<LoginResponse> LoginAsync(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var loginRequest = new
                {
                    nombre = username,
                    contraseña = password
                };

                var jsonContent = JsonConvert.SerializeObject(loginRequest);
                Console.WriteLine("JSON a enviar: " + jsonContent);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                httpContent.Headers.Clear();
                httpContent.Headers.Add("Content-Type", "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/login", httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor: " + jsonResponse);

                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);
                        return loginResponse;
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Error en la respuesta: " + errorResponse);
                        MessageBox.Show("Error en el servidor: " + errorResponse);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Excepción: " + ex.Message);
                    return null;
                }
            }
        }


        public class LoginResponse
        {
            public string Rol { get; set; }
        }

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
            if(text_password.Text == "CONTRASEÑA")
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
