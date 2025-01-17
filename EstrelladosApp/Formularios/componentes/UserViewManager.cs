using EstrelladosApp.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstrelladosApp.Formularios.componentes
{
    public partial class UserViewManager : UserControl
    {
        private List<UsuarioDTO> _usuarios;

        public UserViewManager(List<UsuarioDTO> usuarios)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            _usuarios = usuarios;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            // Aquí puedes llenar un DataGridView o ListView con la lista de usuarios
            dataGridView1.DataSource = _usuarios;
        }
    }

}

