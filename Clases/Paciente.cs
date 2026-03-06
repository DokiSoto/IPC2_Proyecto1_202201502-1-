using System;
using IPC2PROYECTO1.ListasEnlazadas;

namespace IPC2PROYECTO1.Clases
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public int M {  get; set; }
        public int PeriodosMaximos { get; set; }

        public ListaEnlazadaCelda CeldasVivas { get; set; }
        public ListaEnlazadaEstado Estados { get; set; }

        public string Resusltado { get; set; }
        public int N {  get; set; }
        public int N1 { get; set; }

        public Paciente(string nombre, int edad, int m, int periodos)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.M = m;
            this.PeriodosMaximos = periodos;

            this.CeldasVivas = new ListaEnlazadaCelda();
            this.Estados = new ListaEnlazadaEstado();
        }

    }
}
