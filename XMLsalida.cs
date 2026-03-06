using System;
using System.Xml.Linq;
using IPC2PROYECTO1.Clases;
using IPC2PROYECTO1.ListasEnlazadas;

namespace IPC2PROYECTO1
{
    public class XMLsalida
    {
        public void Generar(ListaEnlazadaPaciente pacientes)
        {
            XElement raiz = new XElement("pacientes");

            NodoPaciente actual = pacientes.ObtenerInicio();

            while (actual != null)
            {
                Paciente p = actual.Dato;

                XElement pacienteXML = new XElement("paciente",

                    new XElement("datospersonales",
                        new XElement("nombre", p.Nombre),
                        new XElement("edad", p.Edad)
                    ),

                    new XElement("periodos", p.PeriodosMaximos),
                    new XElement("m", p.M),
                    new XElement("resultadoo", p.Resusltado)
                );

                raiz.Add(pacienteXML);

                actual = actual.Siguiente;
            }

            XDocument documento = new XDocument(raiz);

            documento.Save("salida.xml");

            Console.WriteLine("archivo XML generado correctament");
        }

    }
}
