using System;
using System.Collections.Generic;
using System.Text;
using IPC2PROYECTO1.Clases;

namespace IPC2PROYECTO1
{
    public class NodoPaciente
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
