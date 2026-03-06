using System;
using System.Collections.Generic;
using System.Text;
using IPC2PROYECTO1.Clases;
using IPC2PROYECTO1.ListasEnlazadas;
using System.Xml.Linq;
using System.IO;

namespace IPC2PROYECTO1
{
    public class ControladorSistema
    {
        private ListaEnlazadaPaciente pacientes;
        private Paciente pacienteActual;
        ListaEnlazadaEstado estados = new ListaEnlazadaEstado();
        int periodoActual = 0;

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
            if (pacienteActual == null)
            {
                Console.WriteLine("Debe seleccionar un paciente primero.");
                Console.ReadKey();
                return;
            }

            Simulador sim = new Simulador();
            Visualizador vis = new Visualizador();

            sim.EjecutarUnPeriodo(pacienteActual);

            periodoActual++;

            Estado encontrado = estados.BuscarEstado(pacienteActual.CeldasVivas);

            if (encontrado != null)
            {
                Console.WriteLine("Patron repetido detectado.");
                Console.WriteLine("Periodo actual: " + periodoActual);
                Console.WriteLine("El patron aparecio antes en el periodo: " + encontrado.Periodo);
            }
            else
            {
                estados.Insertar(new Estado(pacienteActual.CeldasVivas, periodoActual));
            }

            vis.ImprimirRejilla(pacienteActual);

            Console.ReadKey();
        }

    


public void EjecutarAuto()
        {
            if (pacienteActual == null)
            {
                Console.WriteLine("Debe seleccionar un paciente primero.");
                Console.ReadKey();
                return;
            }

            int periodo = 0;

            while (periodo < pacienteActual.PeriodosMaximos)
            {
                Estado repetido = pacienteActual.Estados.BuscarEstado(pacienteActual.CeldasVivas);

                if (repetido != null)
                {
                    if (repetido.Periodo == 0)
                        pacienteActual.Resusltado = "mortal";
                    else
                        pacienteActual.Resusltado = "grave";

                    Console.WriteLine("Se detecto repeticion de patron en el periodo: " + periodo);
                    Console.WriteLine("Resultado: " + pacienteActual.Resusltado);
                    return;
                }

                Estado nuevo = new Estado(pacienteActual.CeldasVivas.Clonar(), periodo);
                pacienteActual.Estados.Insertar(nuevo);

                EjecutarUnPeriodo();

                periodo++;
            }

            pacienteActual.Resusltado = "leve";
            Console.WriteLine("No se detectaron repeticiones.");
            Console.WriteLine("Resultado: leve");
        }


        public void GenerarXML()
        {
            XMLsalida generador = new XMLsalida();
            generador.Generar(pacientes);

            Console.ReadKey();

        }

        public void LimpiarMemoria()
        {
            pacientes.Limpiar();
            pacienteActual = null;
            Console.WriteLine("Memoria limpiada.");
        }

        public string GenerarPatron(ListaEnlazadaCelda celdas)
        {
            string patron = "";

            NodoCelda actual = celdas.ObtenerInicio();

            while (actual != null)
            {
                patron += actual.Dato.Fila + "," + actual.Dato.Columna + ";";
                actual = actual.Siguiente;
            }

            return patron;
        }

        

public void GenerarSalidaXML()
    {
        if (pacienteActual == null)
        {
            Console.WriteLine("No hay paciente seleccionado.");
            Console.ReadKey();
            return;
        }

        string ruta = "salida_simulacion.xml";

        XElement pacienteXML = new XElement("paciente",
            new XElement("nombre", pacienteActual.Nombre),
            new XElement("periodo_actual", periodoActual)
        );

        XElement raiz = new XElement("resultados", pacienteXML);

        XDocument doc = new XDocument(raiz);

        doc.Save(ruta);

        Console.WriteLine("Archivo XML generado en: " + Path.GetFullPath(ruta));
        Console.ReadKey();
    }


}
}
