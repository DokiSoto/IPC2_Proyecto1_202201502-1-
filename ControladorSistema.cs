using System;
using System.Collections.Generic;
using System.Text;
using IPC2PROYECTO1.Clases;
using IPC2PROYECTO1.ListasEnlazadas;

namespace IPC2PROYECTO1
{
    public class ControladorSistema
    {
        private ListaEnlazadaPaciente pacientes;
        private Paciente pacienteActual;

        public ControladorSistema()
        {
            pacientes = new ListaEnlazadaPaciente();
            pacienteActual = null;
        }

        public void CargarXML()
        {
            Console.Write("Ingrese la ruta del archivo XML: ");
            string ruta = Console.ReadLine();

            try
            {
                LectorXML lector = new LectorXML();
                pacientes = lector.Leer(ruta);

                Console.WriteLine("Archivo cargado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el XML: " + ex.Message);
            }
        }

        public void SeleccionarPaciente()
        {
            Console.WriteLine("Nombre del paciente: ");
            string nombre = Console.ReadLine();

            pacienteActual = pacientes.BuscarporNombe(nombre);

            if (pacienteActual != null)

                Console.WriteLine("Paciente seleccionado");
            else
                Console.WriteLine("ESE PACIENTE NO EXISTE VOS");

            
        }

        public void EjecutarUnPeriodo()
        {
            if(pacienteActual == null)
            {
                Console.WriteLine("Selecciona un paciente primero");
                return;
            }

            Simulador sim = new Simulador();
            Visualizador vis = new Visualizador();

            sim.EjecutarUnPeriodo(pacienteActual);
            vis.ImprimirRejilla(pacienteActual);

            Console.ReadKey(); ;

            Console.WriteLine("PErdiodo ejecutado)");

        }

        public void EjecutarAuto()
        {
            if(pacienteActual == null)
            {
                Console.WriteLine("Debe seleccionar un paciente primero.");
                return;

            }

            Console.WriteLine("EJECUTANDO AUTOMATICO");
        }

        public void GenerarXML()
        {
            Console.WriteLine("Generando XML de salida...");

        }

        public void LimpiarMemoria()
        {
            pacientes.Limpiar();
            pacienteActual = null;
            Console.WriteLine("Memoria limpiada.");
        }


    }
}
