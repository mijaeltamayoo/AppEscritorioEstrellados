using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstrelladosApp
{
    public partial class Usuario : Form
    {
        private List<UsuarioDTO> usuariosList;

        public Usuario()
        {
            InitializeComponent();
            CargarTablaAsync();
            tabControl1.TabPages[0].Text = "Lista de usuarios";
            tabControl1.TabPages[1].Text = "Detalles de usuario";


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private async Task CargarTablaAsync()
        {
            ApiUsuarios api = new ApiUsuarios();
            usuariosList = await api.GetUsuariosAsync();

            if (usuariosList != null && usuariosList.Count > 0)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Nombre");
                dataTable.Columns.Add("Correo");
                dataTable.Columns.Add("Rol");

                foreach (var usuario in usuariosList)
                {
                    dataTable.Rows.Add(usuario.Id, usuario.Nombre, usuario.Correo, usuario.Rol);
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["ID"].Visible = false;

                comboBox1.Items.Clear();
                comboBox1.Items.Add("administrador");
                comboBox1.Items.Add("usuario");
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios.");
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

        private void panel_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string nombre = nombre_user.Text;
            string email = correo_user.Text;
            string password = passw_user.Text;

            try
            {
                var registerResult = await RegisterAsync(nombre, email, password);

                if (registerResult != null)
                {
                    MessageBox.Show(registerResult.Mensaje);
                }
                else
                {
                    MessageBox.Show("Error al registrar usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task<RegisterResponse> RegisterAsync(string nombre, string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var registerRequest = new
                {
                    nombre = nombre,
                    correo = email,
                    contraseña = password
                };

                var jsonContent = JsonConvert.SerializeObject(registerRequest);
                Console.WriteLine("JSON a enviar: " + jsonContent);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                httpContent.Headers.Clear();
                httpContent.Headers.Add("Content-Type", "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/registro", httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor: " + jsonResponse);
                        return JsonConvert.DeserializeObject<RegisterResponse>(jsonResponse);
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
                    MessageBox.Show("Error en la solicitud: " + ex.Message);
                    return null;
                }
            }
        }


        public class RegisterResponse
        {
            public string Mensaje { get; set; }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int selectedIndex = dataGridView1.CurrentRow.Index;
                UsuarioDTO selectedUser = usuariosList[selectedIndex];

                new_name.Text = selectedUser.Nombre;
                new_correo.Text = selectedUser.Correo;
                new_passw.Text = selectedUser.Contraseña;

                comboBox1.SelectedItem = selectedUser.Rol;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            string nombre = new_name.Text;
            string correo = new_correo.Text;
            string contraseña = new_passw.Text;
            string rol = comboBox1.SelectedItem?.ToString();
            long idUsuario = long.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());

            try
            {
                var updateResult = await ActualizarUsuarioAsync(idUsuario, nombre, correo, contraseña, rol);

                if (updateResult != null)
                {
                    MessageBox.Show(updateResult.Mensaje);
                    await CargarTablaAsync();
                }
                else
                {
                    MessageBox.Show("Error al actualizar usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task<RegisterResponse> ActualizarUsuarioAsync(long id, string nombre, string correo, string contraseña, string rol)
        {
            using (HttpClient client = new HttpClient())
            {
                var updateRequest = new
                {
                    nombre = nombre,
                    correo = correo,
                    contraseña = contraseña,
                    rol = rol
                };

                var jsonContent = JsonConvert.SerializeObject(updateRequest);
                Console.WriteLine("JSON a enviar: " + jsonContent);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PutAsync($"http://localhost:8080/api/usuarios/{id}", httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor: " + jsonResponse);
                        return JsonConvert.DeserializeObject<RegisterResponse>(jsonResponse);
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
                    MessageBox.Show("Error en la solicitud: " + ex.Message);
                    return null;
                }
            }

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            long idUsuario = long.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());

            try
            {
                var deleteResult = await EliminarUsuarioAsync(idUsuario);

                if (deleteResult != null)
                {
                    MessageBox.Show(deleteResult.Mensaje);
                    await CargarTablaAsync();
                }
                else
                {
                    MessageBox.Show("Error al eliminar usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private async Task<RegisterResponse> EliminarUsuarioAsync(long id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync($"http://localhost:8080/api/usuarios/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor: " + jsonResponse);
                        return JsonConvert.DeserializeObject<RegisterResponse>(jsonResponse);
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
                    MessageBox.Show("Error en la solicitud: " + ex.Message);
                    return null;
                }
            }
        }
    }
}

