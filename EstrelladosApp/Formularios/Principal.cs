using EstrelladosApp.DTOs;
using EstrelladosApp.Formularios.componentes;
using EstrelladosApp.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstrelladosApp
{
    public partial class Principal : Form
    {
        private List<RolDTO> _roles;  // Lista para almacenar los roles

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

        private async void UsuariosButton_Click(object sender, EventArgs e)
        {
            // Cargar usuarios y roles
            var usuarios = await new UsuarioService().ObtenerUsuariosAsync();
            _roles = await new RolService().ObtenerRolesAsync();  // Asumiendo que tienes un servicio para roles
            LoadUserControl(new UserViewManager(usuarios, _roles));  // Pasar ambos datos (usuarios y roles) al UserControl
        }
    }
}
