using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace Biblioteca_INE
{
    public class Clase_validaciones
    {
        //BIBLIOTECA AÑADIDA
        //MÉTODO DE CONFIRMACIÓN DE INICIO DE SESIÓN_FORM 1
       
        public static bool Validar_form1(string correo, string contraseña)
        {
            bool camposNoVacios = !string.IsNullOrWhiteSpace(correo) && !string.IsNullOrWhiteSpace(contraseña);
            bool contraseñaValida = Regex.IsMatch(contraseña, @"\d"); // Al menos un número

            return camposNoVacios && contraseñaValida;
        }

        //MÉTODO DE CONFIRMACIÓN DE CITA_FORM 3
        public static bool Validar_form3(string C_entidad, string C_delegacion, string C_modulo,
        string C_fecha, string C_tramite)
        {
            bool entidadValida = false;
            bool delegacionValida = false;
            bool moduloValido = false;
            bool fechaValida = false;
            bool tramiteValido = false;

            // Crear hilos para cada validación
            Thread entidadThread = new Thread(() =>
            {
                entidadValida = !string.IsNullOrWhiteSpace(C_entidad);
            });

            Thread delegacionThread = new Thread(() =>
            {
                delegacionValida = !string.IsNullOrWhiteSpace(C_delegacion);
            });

            Thread moduloThread = new Thread(() =>
            {
                moduloValido = !string.IsNullOrWhiteSpace(C_modulo);
            });

            Thread fechaThread = new Thread(() =>
            {
                fechaValida = !string.IsNullOrWhiteSpace(C_fecha);
            });

            Thread tramiteThread = new Thread(() =>
            {
                tramiteValido = !string.IsNullOrWhiteSpace(C_tramite);
            });

            // Iniciar todos los hilos
            entidadThread.Start();
            delegacionThread.Start();
            moduloThread.Start();
            fechaThread.Start();
            tramiteThread.Start();

            // Esperar que todos terminen
            entidadThread.Join();
            delegacionThread.Join();
            moduloThread.Join();
            fechaThread.Join();
            tramiteThread.Join();

            // Evaluar resultados
            return entidadValida && delegacionValida && moduloValido && fechaValida && tramiteValido;
        }

        //MÉTODO DE UBICACIÓN DE MÓDULO_FORM 4
        public static bool Validar_form4(string C_entidad, string C_municipio)
        {
            bool entidadValida = false;
            bool municipioValido = false;

            // Crear hilos para cada validación
            Thread entidadThread = new Thread(() =>
            {
                entidadValida = !string.IsNullOrWhiteSpace(C_entidad);
            });

            Thread municipioThread = new Thread(() =>
            {
                municipioValido = !string.IsNullOrWhiteSpace(C_municipio);
            });

            // Iniciar los hilos
            entidadThread.Start();
            municipioThread.Start();

            // Esperar que ambos terminen
            entidadThread.Join();
            municipioThread.Join();

            // Evaluar el resultado
            return entidadValida && municipioValido;
        }

        //MÉTODO DE CONFIRMACIÓN DE REGISTRO_FORM 6
        public static bool Validar_form6(string C_nombre, string C_apellidop, string C_apellidom, string C_telefono,
        string C_correo, string C_correo2, string C_contraseña, string C_fecha)
        {
            bool nombreValido = false;
            bool apellidopValido = false;
            bool apellidomValido = false;
            bool telefonoValido = false;
            bool correoValido = false;
            bool correo2Valido = false;
            bool contraseñaValida = false;
            bool fechaValida = false;

            // Crear hilos para cada campo
            Thread nombreThread = new Thread(() => { nombreValido = !string.IsNullOrWhiteSpace(C_nombre); });
            Thread apellidopThread = new Thread(() => { apellidopValido = !string.IsNullOrWhiteSpace(C_apellidop); });
            Thread apellidomThread = new Thread(() => { apellidomValido = !string.IsNullOrWhiteSpace(C_apellidom); });
            Thread telefonoThread = new Thread(() => { telefonoValido = !string.IsNullOrWhiteSpace(C_telefono); });
            Thread correoThread = new Thread(() => { correoValido = !string.IsNullOrWhiteSpace(C_correo); });
            Thread correo2Thread = new Thread(() => { correo2Valido = !string.IsNullOrWhiteSpace(C_correo2); });
            Thread contraseñaThread = new Thread(() => { contraseñaValida = !string.IsNullOrWhiteSpace(C_contraseña); });
            Thread fechaThread = new Thread(() => { fechaValida = !string.IsNullOrWhiteSpace(C_fecha); });

            // Iniciar todos los hilos
            nombreThread.Start();
            apellidopThread.Start();
            apellidomThread.Start();
            telefonoThread.Start();
            correoThread.Start();
            correo2Thread.Start();
            contraseñaThread.Start();
            fechaThread.Start();

            // Esperar que todos terminen
            nombreThread.Join();
            apellidopThread.Join();
            apellidomThread.Join();
            telefonoThread.Join();
            correoThread.Join();
            correo2Thread.Join();
            contraseñaThread.Join();
            fechaThread.Join();

            // Evaluar resultados
            return nombreValido && apellidopValido && apellidomValido && telefonoValido &&
                   correoValido && correo2Valido && contraseñaValida && fechaValida;
        }
    }
}
