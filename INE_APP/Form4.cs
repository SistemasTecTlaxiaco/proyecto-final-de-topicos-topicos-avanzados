using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca_INE;
using MySql.Data.MySqlClient;

namespace INE_APP
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Contenedor.Dock = DockStyle.Fill;
            this.BackColor = ColorTranslator.FromHtml("#FF4D6D");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Contenedor_main.Width = 300;
            Contenedor_main.Height = 350;
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


        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = ColorTranslator.FromHtml("#FFB3C1");
            int radius = 40; // Radio de las esquinas
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel3.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel3.Width - radius, panel3.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel3.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel3.Region = new Region(path);
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Cargar la imagen original
            //Image I1 = Image.FromFile(@"C:\Users\isaia\Desktop\UBICACION.png");

            // Especificar el tamaño deseado en píxeles
            //int width = 100; // Ancho de la imagen redimensionada
            //int height = 100; // Alto de la imagen redimensionada

            // Crear una nueva imagen redimensionada
            //Bitmap resizedImage = new Bitmap(I1, width, height);

            // Asignar la nueva imagen redimensionada al PictureBox
            //pictureBox1.Image = resizedImage;

            Btn_localizar.BackColor = ColorTranslator.FromHtml("#FFCCD5");
        }

















        //CADENA PARA HACER LA CONEXIÓN A LA DB 
        private string connectionString = "server=localhost;port=3306;database=ine;user=root;password=;";
        private bool ExisteModulo(string entidad, string municipio)
        {
            bool existe = false;
            using (MySqlConnection conexion = new MySqlConnection(connectionString)) // Crea la conexión con la base de datos
            {
                try
                {
                    conexion.Open(); // Abre la conexión
                    string consulta = @"SELECT COUNT(*) FROM modulo 
                                WHERE entidad = @entidad AND municipio = @municipio"; // Consulta para verificar si existe el módulo

                    MySqlCommand comando = new MySqlCommand(consulta, conexion); // Prepara el comando con la consulta
                    comando.Parameters.AddWithValue("@entidad", entidad); // Asigna valor al parámetro @entidad
                    comando.Parameters.AddWithValue("@municipio", municipio); // Asigna valor al parámetro @municipio
                    MySqlDataReader lector = comando.ExecuteReader(); // Ejecuta la consulta y obtiene el resultado
                    if (lector.HasRows) // Verifica si se obtuvieron resultados
                    {
                        MessageBox.Show("modulo encontrado.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje si se encontró el módulo
                        existe = true; // Establece que sí existe
                                       // Aquí puedes abrir otro formulario si quieres
                    }
                    else
                    {
                        MessageBox.Show("modulo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje si no se encontró el módulo
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al consultar la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Manejo de errores de conexión o consulta
                }

                return existe; // Retorna si el módulo existe o no
            }
        }

        private string ObtenerDireccionModulo(string entidad, string municipio)
        {
            string direccion = string.Empty;
            using (MySqlConnection conexion = new MySqlConnection(connectionString)) // Crea la conexión con la base de datos
            {
                try
                {
                    conexion.Open(); // Abre la conexión
                    string consulta = @"SELECT direccion FROM modulo 
                                WHERE entidad = @entidad AND municipio = @municipio
                                LIMIT 1"; // Consulta para obtener la dirección del módulo
                    MySqlCommand comando = new MySqlCommand(consulta, conexion); // Prepara el comando con la consulta
                    comando.Parameters.AddWithValue("@entidad", entidad); // Asigna valor al parámetro @entidad
                    comando.Parameters.AddWithValue("@municipio", municipio); // Asigna valor al parámetro @municipio
                    using (MySqlDataReader lector = comando.ExecuteReader()) // Ejecuta la consulta y obtiene el resultado
                    {
                        if (lector.Read()) // Verifica si hay un resultado
                        {
                            direccion = lector["direccion"].ToString(); // Obtiene el valor de la dirección
                            MessageBox.Show("Módulo encontrado.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                            // Muestra mensaje si se encontró el módulo
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el módulo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                            // Muestra mensaje si no se encontró el módulo
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al consultar la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Manejo de errores de conexión o consulta
                }
            }
            return direccion; // Retorna la dirección del módulo si se encontró
        }

        private void Btn_localizar_Click(object sender, EventArgs e)
        {
            bool datos_correctos = Clase_validaciones.Validar_form4(C_entidad.Text, C_municipio.Text);//llamado al metodo y guardado de su valor boleano
            if (datos_correctos)//comparación del valor voleano
            {
                DialogResult result = MessageBox.Show("¿Datos correctos?", "confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);//mensaje de confirmacion
                    if (result == DialogResult.Yes && ExisteModulo(C_entidad.Text,C_municipio.Text)){//al aceptar
                        MessageBox.Show("MODULO UBICADO", "Informacion", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);//mensaje de confirmacion
                    
                    
                    this.C_direccion.Text =ObtenerDireccionModulo(C_entidad.Text, C_municipio.Text);
                    this.C_entidad.Text = "";
                    this.C_municipio.Text = "";
                }
                else//al negar
                {
                    //borrar el contenido de los campos de texto
                    this.C_entidad.Focus();
                    this.C_entidad.Text = "";
                    this.C_municipio.Text = "";
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
