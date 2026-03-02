using System;
using System.Collections.Generic;
using System.Text;
using IPC2PROYECTO1.Clases;
using IPC2PROYECTO1.ListasEnlazadas;
namespace IPC2PROYECTO1
{
    public class ListaEnlazadaPaciente
    {
        private NodoPaciente inicio;
        private int count;

        public ListaEnlazadaPaciente()
        {
            this.inicio = null;
            this.count = 0;
        }

        public int GetTamano()
        {
            return count;
        }

        public void InsertarFinal(Paciente paciente)
        {
            NodoPaciente nuevo = new NodoPaciente(paciente);

            if (this.inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                NodoPaciente actual = inicio;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
            count++;
        }

        public Paciente BuscarporNombe(string nombre)
        {
            NodoPaciente actual = inicio;

            while(actual != null)
            {
                if(actual.Dato.Nombre == nombre)
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
        public bool EliminarporNombre(string nombre)
        {
            if (this.inicio == null)
                return false;

            if(inicio.Dato.Nombre == nombre)
            {
                inicio = inicio.Siguiente;
                count--;
                return true;
            }
            NodoPaciente actual = inicio;

            while(actual.Siguiente != null && actual.Siguiente.Dato.Nombre != nombre)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente == null)
                return false;

            actual.Siguiente = actual.Siguiente.Siguiente;
            count--;
            return true;
        }

        public void Imprimir()
        {
            NodoPaciente actual = inicio;

            while(actual != null)
            {
                Console.WriteLine(actual.Dato.Nombre);
                actual = actual.Siguiente;
            }
        }

    }
}
