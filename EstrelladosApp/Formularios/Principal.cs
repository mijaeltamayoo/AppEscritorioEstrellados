using EstrelladosApp.DTOs;
using EstrelladosApp.Formularios.componentes;
using EstrelladosApp.Servicios;
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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        

        private void LoadUserControl(UserControl control)
        {
            mainPanel.Controls.Clear(); // Limpiar el panel principal
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }

        private void GraficosButton_Click(object sender, EventArgs e)
        {

        }

        private async void UsuariosButton_Click(object sender, EventArgs e)
        {
            var usuarios = await new UsuarioService().ObtenerUsuariosAsync();
            LoadUserControl(new UserViewManager(usuarios));
        }
    }
}
