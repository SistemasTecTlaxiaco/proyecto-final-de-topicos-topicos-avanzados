using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca_INE;
using MySql.Data.MySqlClient;

namespace INE_APP
{
    public partial class Form7 : Form
    { // Componentes definidos
        private Panel panelMenu;
        private Panel panelMain;
        private Panel panelControles;

        private Button btnUsuario;
        private Button btnModulo;
        private Button btnCita;

        private Button btnEliminar;
        private Button btnEditar;
        private Button btnActualizar;

        private DataGridView dgvConsulta;
        private string tablaSeleccionada = "";
        private string connectionString = "server=localhost;port=3306;database=ine;user=root;password=;";
        public Form7()
        {

            InitializeComponent();
            InicializarDiseñoFlat();

            // Asociar eventos
            btnUsuario.Click += btnUsuario_Click;
            btnModulo.Click += btnModulo_Click;
            btnCita.Click += btnCita_Click;
            btnEliminar.Click += BtnEliminar_Click;
        }


        private void InicializarDiseñoFlat()
        {
            this.Text = "CONSULTAS";
            this.Size = new Size(1000, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = ColorTranslator.FromHtml("#FF4D6D");

            // Panel lateral
            panelMenu = new Panel();
            panelMenu.Size = new Size(200, this.ClientSize.Height);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.BackColor = ColorTranslator.FromHtml("#FFB3C1");
            this.Controls.Add(panelMenu);

            // Botón USUARIO
            btnUsuario = new Button();
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Text = "USUARIO";
            btnUsuario.Size = new Size(180, 45);
            btnUsuario.Location = new Point(10, 30);
            btnUsuario.FlatStyle = FlatStyle.Flat;
            btnUsuario.BackColor = ColorTranslator.FromHtml("#FFCCD5");
            btnUsuario.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMenu.Controls.Add(btnUsuario);



            // Botón MODULO
            btnModulo = new Button();
            btnModulo.Name = "btnModulo";
            btnModulo.Text = "MODULO";
            btnModulo.Size = new Size(180, 45);
            btnModulo.Location = new Point(10, 90);
            btnModulo.FlatStyle = FlatStyle.Flat;
            btnModulo.BackColor = ColorTranslator.FromHtml("#FFCCD5");
            btnModulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMenu.Controls.Add(btnModulo);

            // Botón CITA
            btnCita = new Button();
            btnCita.Name = "btnCita";
            btnCita.Text = "CITA";
            btnCita.Size = new Size(180, 45);
            btnCita.Location = new Point(10, 150);
            btnCita.FlatStyle = FlatStyle.Flat;
            btnCita.BackColor = ColorTranslator.FromHtml("#FFCCD5");
            btnCita.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMenu.Controls.Add(btnCita);

            // Panel principal
            panelMain = new Panel();
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackColor = Color.White;
            this.Controls.Add(panelMain);

            // DataGridView
            dgvConsulta = new DataGridView();
            dgvConsulta.Name = "dgvConsulta";
            dgvConsulta.Dock = DockStyle.Fill;
            dgvConsulta.ReadOnly = true;
            dgvConsulta.BackgroundColor = Color.White;
            dgvConsulta.BorderStyle = BorderStyle.None;
            dgvConsulta.AllowUserToAddRows = false;
            dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            panelMain.Controls.Add(dgvConsulta);

            // Panel inferior para botones de acción
            panelControles = new Panel();
            panelControles.Name = "panelControles";
            panelControles.Height = 60;
            panelControles.Dock = DockStyle.Bottom;
            panelControles.BackColor = ColorTranslator.FromHtml("#FFB3C1");
            panelMain.Controls.Add(panelControles);

            // Botón ELIMINAR
            btnEliminar = new Button();
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.Size = new Size(120, 40);
            btnEliminar.Location = new Point(210, 10);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.BackColor = ColorTranslator.FromHtml("#FFCCD5");
            btnEliminar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            panelControles.Controls.Add(btnEliminar);
        }
        private void CargarDatos()
        {
            if (string.IsNullOrEmpty(tablaSeleccionada))
            {
                MessageBox.Show("No se ha seleccionado ninguna tabla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string consulta = $"SELECT * FROM {tablaSeleccionada}";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    // Comprobación: Mostrar nombres de columnas cargadas
                    foreach (DataColumn col in tabla.Columns)
                    {
                        Console.WriteLine(col.ColumnName);
                    }

                    dgvConsulta.DataSource = tabla;

                    // Asegurar que no hay columnas ocultas
                    foreach (DataGridViewColumn col in dgvConsulta.Columns)
                    {
                        col.Visible = true;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al cargar los datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            tablaSeleccionada = "usuario";
            CargarDatos();
        }

        private void btnModulo_Click(object sender, EventArgs e)
        {
            tablaSeleccionada = "modulo";
            CargarDatos();
        }

        private void btnCita_Click(object sender, EventArgs e)
        {
            tablaSeleccionada = "cita";
            CargarDatos();
        }


        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tablaSeleccionada))
            {
                MessageBox.Show("Primero selecciona una tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campoId = "";

            // Determinar el nombre del campo ID según la tabla
            if (tablaSeleccionada == "usuario")
                campoId = "id_usuario";
            else if (tablaSeleccionada == "modulo")
                campoId = "id_modulo";
            else if (tablaSeleccionada == "cita")
                campoId = "id_cita";
            else
            {
                MessageBox.Show("Tabla no reconocida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    // Consulta para eliminar el registro con el ID más alto
                    string consulta = $"DELETE FROM {tablaSeleccionada} WHERE {campoId} = (SELECT MAX({campoId}) FROM {tablaSeleccionada})";

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos(); // Refrescar los datos
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún registro para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al eliminar el registro:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
