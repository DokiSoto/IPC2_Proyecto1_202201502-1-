using IPC2PROYECTO1.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2PROYECTO1
{
    public class NodoEstado
    {
        public Estado Dato;
        public NodoEstado Siguiente;

        public NodoEstado(Estado dato)
        {
            this.Dato = dato;
            this.Siguiente = null;
        }
    }
}
