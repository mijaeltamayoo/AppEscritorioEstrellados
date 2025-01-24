using EstrelladosApp.DTOs;
using EstrelladosApp.Formularios.componentes;
using EstrelladosApp.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstrelladosApp
{
    public partial class Principal : Form
    {
        private List<RolDTO> _roles;  // Lista para almacenar los roles
        private List<IncidenciaDTO> incidencias;
        private List<CiudadDTO> ciudades;
        private List<ProvinciaDTO> provincias;
        private List<RegionDTO> regiones;
        private List<TipoIncidenciaDTO> tiposIncidencia;

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
            _roles = await new RolService().ObtenerRolesAsync();  
            LoadUserControl(new UserViewManager(usuarios, _roles));  // Pasar ambos datos (usuarios y roles) al UserControl
        }

        private async void IncidenciasButton_Click(object sender, EventArgs e)
        {
            // Llamar a los servicios para cargar datos
            incidencias = await new IncidenciaService().ObtenerIncidenciasAsync();
            ciudades = await new CiudadService().ObtenerCiudadesAsync();
            provincias = await new ProvinciaService().ObtenerProvinciasAsync();
            regiones = await new RegionService().ObtenerRegionesAsync();
            tiposIncidencia = await new TipoIncidenciaService().ObtenerTiposIncidenciaAsync();

            LoadUserControl(new IncidenciaViewManager( incidencias, ciudades, provincias, regiones, tiposIncidencia));
        }
    }
}
