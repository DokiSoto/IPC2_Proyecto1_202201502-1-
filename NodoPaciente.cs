using System;

using IPC2PROYECTO1.Clases;

namespace IPC2PROYECTO1
{
    public class NodoPaciente : Nodo 
    {
        public Paciente Dato;
        public NodoPaciente Siguiente;

        public NodoPaciente(Paciente dato)
        {
            this.Dato = dato;
            this.Siguiente = null;
        }
    }
}
