using EstrelladosApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EstrelladosApp.Formularios.componentes
{
    public partial class UserViewManager : UserControl
    {
        private List<UsuarioDTO> _usuarios;
        private List<RolDTO> _roles;  // Lista de roles

        public UserViewManager(List<UsuarioDTO> usuarios, List<RolDTO> roles)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            _usuarios = usuarios;
            _roles = roles;

            ConfigurarDataGridView();
            RefrescarUsuarios();
            CargarRolesEnComboBox();  // Llamar al método para cargar los roles
        }

        // Cargar roles en el ComboBox de rol
        private void CargarRolesEnComboBox()
        {
            rolComboBox.DataSource = _roles;
            rolComboBox.DisplayMember = "Nombre";  // Mostrar el nombre del rol
            rolComboBox.ValueMember = "Id";  // Usar el ID del rol
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();

            // Configuración de columnas (como antes)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                ReadOnly = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Correo",
                HeaderText = "Correo",
                DataPropertyName = "Correo",
                ReadOnly = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Contraseña",
                HeaderText = "Contraseña",
                DataPropertyName = "Contraseña",
                ReadOnly = false
            });

            var rolColumn = new DataGridViewComboBoxColumn
            {
                Name = "Rol",
                HeaderText = "Rol",
                DataPropertyName = "Rol.Id",
                DataSource = _roles,
                DisplayMember = "Nombre",
                ValueMember = "Id"
            };
            dataGridView1.Columns.Add(rolColumn);

            var actionColumn = new DataGridViewButtonColumn
            {
                Name = "Acciones",
                HeaderText = "Acciones",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(actionColumn);

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void RefrescarUsuarios()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _usuarios;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
                {
                    EliminarUsuario(e.RowIndex);
                }
            }
        }

        private void EliminarUsuario(int rowIndex)
        {
            var usuario = _usuarios[rowIndex];
            if (MessageBox.Show($"¿Está seguro de que desea eliminar al usuario {usuario.Nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _usuarios.RemoveAt(rowIndex);
                RefrescarUsuarios();
                MessageBox.Show($"Usuario {usuario.Nombre} eliminado correctamente.");
            }
        }

        // Evento para el botón "Nuevo Usuario"
        private void NewUsuarioBTN_Click(object sender, EventArgs e)
        {
            // Validar campos
            string nombre = NombreTextBox.Text;
            string correo = CorreoTextBox.Text;
            string contraseña = ContraseñaTextBox.Text;
            var rolId = rolComboBox.SelectedValue;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("El correo electrónico no es válido.");
                return;
            }

            // Crear el nuevo usuario
            long nuevoId = _usuarios.Count > 0 ? _usuarios.Max(u => u.Id) + 1 : 1;
            var nuevoUsuario = new UsuarioDTO
            {
                Id = nuevoId,
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseña,
                Rol = _roles.FirstOrDefault(r => r.Id == (long)rolId)
            };

            _usuarios.Add(nuevoUsuario);
            RefrescarUsuarios();
            MessageBox.Show($"Usuario {nombre} guardado correctamente.");
        }

        // Validar el formato del correo electrónico
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron);
        }
    }
}
