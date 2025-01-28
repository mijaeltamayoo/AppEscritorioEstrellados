using EstrelladosApp.DTOs;
using EstrelladosApp.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstrelladosApp.Formularios.componentes
{
    public partial class IncidenciaViewManager : UserControl
    {
        private List<IncidenciaDTO> _incidencias;
        private List<CiudadDTO> _ciudades;
        private List<ProvinciaDTO> _provincias;
        private List<RegionDTO> _regiones;
        private List<TipoIncidenciaDTO> _tiposIncidencia;

        public IncidenciaViewManager(
            List<IncidenciaDTO> incidencias,
            List<CiudadDTO> ciudades,
            List<ProvinciaDTO> provincias,
            List<RegionDTO> regiones,
            List<TipoIncidenciaDTO> tiposIncidencia)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            _incidencias = incidencias;
            _ciudades = ciudades;
            _provincias = provincias;
            _regiones = regiones;
            _tiposIncidencia = tiposIncidencia;

            ConfigurarDataGridView();
            RefrescarIncidenciasAsync();
            ConfigurarComboboxes();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();

            // Configuración de columnas de texto estándar
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Latitud",
                HeaderText = "Latitud",
                DataPropertyName = "Latitud",
                ReadOnly = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Longitud",
                HeaderText = "Longitud",
                DataPropertyName = "Longitud",
                ReadOnly = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Causa",
                HeaderText = "Causa",
                DataPropertyName = "Causa",
                ReadOnly = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NivelIncidencia",
                HeaderText = "Nivel Incidencia",
                DataPropertyName = "NivelIncidencia",
                ReadOnly = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Carretera",
                HeaderText = "Carretera",
                DataPropertyName = "Carretera",
                ReadOnly = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaInicio",
                HeaderText = "Fecha Inicio",
                DataPropertyName = "FechaInicio",
                ReadOnly = true
            });

            // Columna para mostrar el nombre de la ciudad
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Ciudad",
                HeaderText = "Ciudad",
                DataPropertyName = "CiudadNombre", 
                ReadOnly = true
            });

            // Columna para mostrar el nombre de la provincia
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Provincia",
                HeaderText = "Provincia",
                DataPropertyName = "ProvinciaNombre", 
                ReadOnly = true
            });

            // Columna para mostrar el nombre de la región
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Region",
                HeaderText = "Región",
                DataPropertyName = "RegionNombre", 
                ReadOnly = true
            });

            // Columna para mostrar el tipo de incidencia
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoIncidencia",
                HeaderText = "Tipo de Incidencia",
                DataPropertyName = "TipoIncidenciaNombre", 
                ReadOnly = true
            });

            var actionColumn = new DataGridViewButtonColumn
            {
                Name = "Acciones",
                HeaderText = "Acciones",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(actionColumn);

            dataGridView1.CellClick += DataGridView1_CellClick;
        }


        private async Task RefrescarIncidenciasAsync()
        {
            _incidencias.Clear();
            _incidencias = await new IncidenciaService().ObtenerIncidenciasAsync();
            var incidenciasExtendidas = _incidencias.Select(i => new
            {
                i.Id,
                i.Latitud,
                i.Longitud,
                i.Causa,
                i.NivelIncidencia,
                i.Carretera,
                i.FechaInicio,

                CiudadNombre = _ciudades.FirstOrDefault(c => c.Id == (i.Ciudad?.Id ?? -1))?.Nombre ?? "N/A",
                ProvinciaNombre = _provincias.FirstOrDefault(p => p.Id == (i.Provincia?.Id ?? -1))?.Nombre ?? "N/A",
                RegionNombre = _regiones.FirstOrDefault(r => r.IdRegion == (i.Region?.Id ?? -1))?.NombreEs ?? "N/A",
                TipoIncidenciaNombre = _tiposIncidencia.FirstOrDefault(t => t.Id == (i.TipoIncidencia?.Id ?? -1))?.Nombre ?? "N/A"
            }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = incidenciasExtendidas;
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
                {
                    EliminarIncidencia(e.RowIndex);
                }
            }
        }

        private async void EliminarIncidencia(int rowIndex)
        {
            var incidencia = _incidencias[rowIndex];
            if (MessageBox.Show($"¿Está seguro de que desea eliminar la incidencia ID {incidencia.Id}?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var nuevaIncidencia = new IncidenciafkDTO
                {
                    id = incidencia.Id,
                };
                if (await new IncidenciaService().deleteIncidencia(nuevaIncidencia))
                {

                    RefrescarIncidenciasAsync();
                    MessageBox.Show($"Incidencia por {nuevaIncidencia.causa} eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show($"Incidencia por {nuevaIncidencia.causa} no eliminado ");
                }

            }
        }
        // Método para configurar los combobox
        private void ConfigurarComboboxes()
        {
            // Combobox de ciudades
            ciudadComboBox1.DataSource = _ciudades;
            ciudadComboBox1.DisplayMember = "Nombre"; // Campo que se muestra en el combobox
            ciudadComboBox1.ValueMember = "Id";      // Campo que representa el identificador

            // Combobox de provincias
            provinciaComboBox.DataSource = _provincias;
            provinciaComboBox.DisplayMember = "Nombre";
            provinciaComboBox.ValueMember = "Id";

            // Combobox de regiones
            regionComboBox.DataSource = _regiones;
            regionComboBox.DisplayMember = "NombreEs"; // Por ejemplo, nombre en español
            regionComboBox.ValueMember = "IdRegion";

            // Combobox de tipos de incidencia
            tipoIncidenciaComboBox.DataSource = _tiposIncidencia;
            tipoIncidenciaComboBox.DisplayMember = "Nombre";
            tipoIncidenciaComboBox.ValueMember = "Id";
        }


        private void ciudadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void provinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ciudadComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void guardarIncidenciaBTN_Click(object sender, EventArgs e)
        {
            int ciudadId = (int)ciudadComboBox1.SelectedValue;
            int provinciaId = (int)provinciaComboBox.SelectedValue;
            int regionId = (int)regionComboBox.SelectedValue; 
            int tipoIncidenciaId = (int)tipoIncidenciaComboBox.SelectedValue;

            var nuevaIncidencia = new IncidenciafkDTO
            {
                latitud = latitudTextBox.Text,
                longitud = longitudTextBox.Text,
                causa = causaTextBox.Text,
                nivelIncidencia = nivelIncidenciaTextBox.Text,
                carretera = carreteraTextBox5.Text,
                fechaInicio = fechaInicioDateTimePicker.Value,
                idCiudad = ciudadId,
                idRegion = regionId,
                idTipoIncidencia = tipoIncidenciaId
            };

            if (await new IncidenciaService().RegistrarIncidencia(nuevaIncidencia))
            {

                RefrescarIncidenciasAsync();
                MessageBox.Show($"Incidencia por {nuevaIncidencia.causa} guardado correctamente.");
            }
            else
            {
                MessageBox.Show($"Incidencia por {nuevaIncidencia.causa} no guardado ");
            }
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
