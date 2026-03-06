using IPC2PROYECTO1.ListasEnlazadas;
using System;


namespace IPC2PROYECTO1.Clases
{
    public class Estado
    {
        public ListaEnlazadaCelda Celdas { get; set; }
        public int Periodo { get; set; }

        public Estado(ListaEnlazadaCelda celdas, int periodo)
        {
            Celdas = celdas;
            Periodo = periodo;
        }
    }
}
