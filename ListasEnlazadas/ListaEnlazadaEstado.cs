using IPC2PROYECTO1.Clases;
using System;

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

        public Estado BuscarEstado(ListaEnlazadaCelda celdas)
        {
            NodoEstado actual = inicio;

            while (actual != null)
            {
                if (CompararListas(actual.Dato.Celdas, celdas))
                {
                    return actual.Dato;
                }

                actual = actual.Siguiente;
            }

            return null;
        }

        private bool CompararListas(ListaEnlazadaCelda a, ListaEnlazadaCelda b)
        {
            NodoCelda actual = a.ObtenerInicio();

            while (actual != null)
            {
                if (!b.Existe(actual.Dato.Fila, actual.Dato.Columna))
                {
                    return false;
                }

                actual = actual.Siguiente;
            }

            actual = b.ObtenerInicio();

            while (actual != null)
            {
                if (!a.Existe(actual.Dato.Fila, actual.Dato.Columna))
                {
                    return false;
                }

                actual = actual.Siguiente;
            }

            return true;
        }
    }
}
