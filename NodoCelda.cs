using System;
using System.Collections.Generic;
using System.Text;
using IPC2PROYECTO1.Clases;

namespace IPC2PROYECTO1
{
    public class NodoCelda
    {
        public Celda Dato;
        public NodoCelda Siguiente;

        public NodoCelda(Celda dato)
        {
            this.Dato = dato;
            this.Siguiente = null;
        }
    }
}
