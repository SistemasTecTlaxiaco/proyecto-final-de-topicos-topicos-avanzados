using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Biblioteca_INE;
using MySql.Data.MySqlClient;

namespace INE_APP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Contenedor.Dock = DockStyle.Fill;
            this.BackColor = ColorTranslator.FromHtml("#FF4D6D");
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#FFB3C1");
            int radius = 40; // Radio de las esquinas
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel1.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel1.Width - radius, panel1.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel1.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel1.Region = new Region(path);
            panel1.Height = 300;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Btn_confirmar.BackColor = ColorTranslator.FromHtml("#FFCCD5");
        }
        // CADENA PARA HACER LA CONEXIÓN A LA DB
        private string connectionString = "server=localhost;port=3306;database=ine;user=root;password=;";
        // Método que registra una nueva cita en la tabla 'cita'
        private bool registrar_cita(string entidad, string delegacion, string modulo,
                                    string fecha, string tramite)
        {
            bool flag = false; // Indicador de éxito del registro
                               // Se establece la conexión con la base de datos usando la cadena definida
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre la conexión con la base de datos
                    conexion.Open();
                    // Consulta SQL de inserción de datos en la tabla 'cita'
                    string consulta = @"INSERT INTO cita 
                        (entidad, municipio, modulo, fecha, tramite) 
                        VALUES 
                        (@entidad, @delegacion, @modulo, @fecha, @tramite)";
                    // Se crea un comando SQL con la consulta y la conexión activa
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    // Se añaden parámetros con los valores recibidos, para evitar inyección SQL
                    comando.Parameters.AddWithValue("@entidad", entidad);
                    comando.Parameters.AddWithValue("@delegacion", delegacion);
                    comando.Parameters.AddWithValue("@modulo", modulo);
                    comando.Parameters.AddWithValue("@fecha", fecha);
                    comando.Parameters.AddWithValue("@tramite", tramite);
                    // Ejecuta la consulta y devuelve cuántas filas fueron afectadas (debería ser 1)
                    int filasAfectadas = comando.ExecuteNonQuery();
                    // Si se insertó al menos una fila, el registro fue exitoso
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Cita registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flag = true; // Marca que el registro fue exitoso
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    // Muestra un mensaje de error si ocurrió una excepción al ejecutar la consulta
                    MessageBox.Show("Error al registrar la cita:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Devuelve true si el registro fue exitoso, false si no
                return flag;
            }
        }


        private void Btn_confirmar_Click(object sender, EventArgs e)
        {
            bool datos_correctos = Clase_validaciones.Validar_form3(C_entidad.Text, C_delegacion.Text, C_modulo.Text, C_fecha.Text, C_tramite.Text);//llamado al metodo y guardado de su valor boleano
            if (datos_correctos)//comparación del valor voleano
            {
                DialogResult result = MessageBox.Show("¿Datos correctos?", "confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);//mensaje de confirmacion
                if (result == DialogResult.Yes && registrar_cita(C_entidad.Text, C_delegacion.Text, C_modulo.Text,
         C_fecha.Text, C_tramite.Text))
                {//al aceptar
                    MessageBox.Show("CITA AGENDADA", "Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);//mensaje de confirmacion
                    // Crea una instancia de Form
                    Form1 form1 = new Form1();
                    // Muestra el Form
                    form1.Show(); // Abre Form de forma no modal (el usuario puede
                                  // interactuar con ambos formularios).
                }
                else//al negar
                {
                    //borrar el contenido de los campos de texto
                    this.C_entidad.Focus();
                    this.C_entidad.Text="";
                    this.C_delegacion.Text = "";
                    this.C_modulo.Text = "";
                    this.C_fecha.Text = "";
                    this.C_tramite.Text = "";
                }
            }
            else
            {
                MessageBox.Show("REVISAR CAMPOS", "ERROR DE DATOS",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
