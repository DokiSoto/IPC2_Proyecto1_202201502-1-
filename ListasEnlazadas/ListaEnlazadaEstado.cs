using IPC2PROYECTO1.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2PROYECTO1.ListasEnlazadas
{
    public class ListaEnlazadaEstado
    {
        private NodoEstado inicio;
        private int count;

        public ListaEnlazadaEstado()
        {
            inicio = null;
            count = 0;
        }

        public void Insertar(Estado estado)
        {
            NodoEstado nuevo = new NodoEstado(estado);

            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                NodoEstado actual = inicio;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }

            count++;
        }

        public Estado BuscarPorPatron(string patron)
        {
            NodoEstado actual = inicio;

            while (actual != null)
            {
                if (actual.Dato.Patron == patron)
                    return actual.Dato;

                actual = actual.Siguiente;
            }

            return null;
        }
    }
}
