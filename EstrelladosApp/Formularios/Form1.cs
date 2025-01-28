using EstrelladosApp.Servicios;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EstrelladosApp
{
    public partial class Form1 : Form
    {
        private readonly AuthService _authService;
        // Importar las funciones de la API de Windows
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wparam, int lparam);

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        public Form1()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

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
                var loginResult = await _authService.LoginAsync(usuario, password);

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
