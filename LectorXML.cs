using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2PROYECTO1
{
    using IPC2PROYECTO1.Clases;
    using System;
    using System.Xml;

    public class LectorXML
    {
        public ListaEnlazadaPaciente Leer(string ruta)
        {
            ListaEnlazadaPaciente listaPacientes = new ListaEnlazadaPaciente();

            XmlDocument doc = new XmlDocument();
            doc.Load(ruta);

            XmlNodeList pacientes = doc.GetElementsByTagName("paciente");

            foreach (XmlNode pacienteNode in pacientes)
            {
                XmlNode datos = pacienteNode.SelectSingleNode("datospersonales");

                string nombre = datos["nombre"].InnerText;
                int edad = int.Parse(datos["edad"].InnerText);

                int periodos = int.Parse(pacienteNode["periodos"].InnerText);
                int m = int.Parse(pacienteNode["m"].InnerText);

                Paciente paciente = new Paciente(nombre, edad, m, periodos);

                XmlNode rejilla = pacienteNode.SelectSingleNode("rejilla");

                if (rejilla != null)
                {
                    XmlNodeList celdas = rejilla.SelectNodes("celda");

                    foreach (XmlNode celda in celdas)
                    {
                        int fila = int.Parse(celda.Attributes["f"].Value);
                        int columna = int.Parse(celda.Attributes["c"].Value);

                        paciente.CeldasVivas.Insertar(new Celda(fila, columna));
                    }
                }

                listaPacientes.InsertarFinal(paciente);
            }

            return listaPacientes;
        }
    }
}
