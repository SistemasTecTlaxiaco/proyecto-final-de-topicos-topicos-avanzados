using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Biblioteca_INE;
using MySql.Data.MySqlClient;

namespace INE_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Sin borde
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#FF4D6D"); // Fondo del formulario principal

            // Estilo flat del botón
            Btn_entrar.BackColor = ColorTranslator.FromHtml("#FFCCD5");
            Btn_entrar.FlatStyle = FlatStyle.Flat;
            Btn_entrar.FlatAppearance.BorderSize = 0;
            Btn_entrar.ForeColor = Color.Black;
            Btn_entrar.Cursor = Cursors.Hand;

            // Fondo del título
            Titulo.BackColor = ColorTranslator.FromHtml("#FFB3C1");
            Titulo.ForeColor = Color.Black;

            // TextBoxes estilo flat
            C_correo.BorderStyle = BorderStyle.None;
            C_correo.BackColor = Color.White;
            C_correo.ForeColor = Color.Black;

            C_contraseña.BorderStyle = BorderStyle.None;
            C_contraseña.BackColor = Color.White;
            C_contraseña.ForeColor = Color.Black;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Titulo.Left = (this.ClientSize.Width - Titulo.Width) / 2;
            Titulo.Top = 40; // Mejor alineación vertical fija
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            panel1.Width = 320;
            panel1.Height = 300;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;

            // Redondear panel estilo flat
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel1.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel1.Width - radius, panel1.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel1.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panel1.Region = new Region(path);
            panel1.BackColor = ColorTranslator.FromHtml("#FFB3C1");
        }


        private void textBox1_Paint(object sender, PaintEventArgs e)
        {
            // Establecer el padding para el TextBox
            int paddingLeft = 20;
            int paddingTop = 10;
            int paddingRight = 20;
            int paddingBottom = 10;
            // Crear un rectángulo con el padding definido
            Rectangle rect = new Rectangle(
                paddingLeft,
                paddingTop,
                C_correo.ClientSize.Width - paddingLeft - paddingRight,
                C_correo.ClientSize.Height - paddingTop - paddingBottom
            );
            // Dibujar el texto dentro del área con padding
            e.Graphics.FillRectangle(Brushes.White, rect);
            e.Graphics.DrawString(C_correo.Text, C_correo.Font, Brushes.Black, rect);
        }

// Cadena de conexión a la base de datos MySQL
private string connectionString = "server=localhost;port=3306;database=ine;user=root;password=;";
        // Método que valida si un usuario existe en la base de datos con nombre y contraseña correctos
        private bool validar_usuario(string nombre, string contra)
        {
            bool flag = false; // Indicador para saber si el usuario fue validado correctamente
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre la conexión a la base de datos
                    conexion.Open();
                    MessageBox.Show("Conexión exitosa a MySQL", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Consulta SQL que busca al usuario con el nombre y contraseña proporcionados
                    string consulta = "SELECT * FROM usuario WHERE nombre = @nombre AND contraseña = @contraseña";
                    // Se prepara el comando SQL con los parámetros para evitar inyección SQL
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombre", nombre);        // Se asigna el valor al parámetro @nombre
                    comando.Parameters.AddWithValue("@contraseña", contra);    // Se asigna el valor al parámetro @contraseña
                                                                               // Ejecuta la consulta y obtiene los resultados en un lector
                    MySqlDataReader lector = comando.ExecuteReader();
                    // Si se encontraron filas, significa que el usuario y contraseña son válidos
                    if (lector.HasRows)
                    {
                        MessageBox.Show("Usuario encontrado. Inicio de sesión exitoso.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flag = true; // Se marca como verdadero para indicar éxito en la validación
                                     // Aquí podrías abrir otro formulario si el login es exitoso
                    }
                    else
                    {
                        // Si no se encontraron registros, se muestra un mensaje de error
                        MessageBox.Show("Correo o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    lector.Close(); // Se cierra el lector de datos
                }
                catch (MySqlException ex)
                {
                    // En caso de error al conectar o ejecutar la consulta, se muestra el mensaje de error
                    MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return flag; // Se retorna true si el usuario fue validado, false si no
            }
        }











        private void button1_Click(object sender, EventArgs e)
        {
            bool datos_correctos = Clase_validaciones.Validar_form1(C_correo.Text, C_contraseña.Text);//llamado al metodo y guardado de su valor boleano
            if (datos_correctos)//comparación del valor voleano
            {
                DialogResult result = MessageBox.Show("¿Datos correctos?", "confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);//mensaje de confirmacion
                if (result == DialogResult.Yes && validar_usuario(C_correo.Text, C_contraseña.Text)
                    )
                {//al aceptar
                    MessageBox.Show("SESIÓN INICIADA", "Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);//mensaje de confirmacion
                                                                          // Crea una instancia de Form2
                    Form2 form2 = new Form2();
                    // Muestra el Form2
                    form2.Show(); // Abre Form2 de forma no modal (el usuario puede interactuar con ambos
                                  // formularios).

                }
                else
                {//al negar
                    C_correo.Focus();
                    this.C_correo.Text = "";
                    this.C_contraseña.Text = "";

                }
            }
            else
            {
                MessageBox.Show("error de datos", "ERROR DE DATOS",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            // Crea una instancia de Form2
            Form6 form6 = new Form6();
            // Muestra el Form2
            form6.Show(); // Abre Form2 de forma no modal
                          // (el usuario puede interactuar con ambos formularios).
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Crea una instancia de Form2
            Form7 form7 = new Form7();
            // Muestra el Form2
            form7.Show(); // Abre Form2 de forma no modal
                          // (el usuario puede interactuar con ambos formularios).
        }

        private void Contenedor_1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
