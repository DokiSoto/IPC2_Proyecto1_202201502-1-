using IPC2PROYECTO1.Clases;
using System;


namespace IPC2PROYECTO1.ListasEnlazadas
{
    public class ListaEnlazadaCelda
    {
        private NodoCelda inicio;
        private int count;

        public ListaEnlazadaCelda()
        {
            inicio = null;
            count = 0;
        }

        public void Insertar(Celda celda)
        {
            NodoCelda nuevo = new NodoCelda(celda);

            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                NodoCelda actual = inicio;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }

            count++;
        }

        public bool Existe(int fila, int columna)
        {
            NodoCelda actual = inicio;

            while (actual != null)
            {
                if(actual.Dato.Fila == fila && actual.Dato.Columna == columna)
                    return true;

                actual = actual.Siguiente;
            }
            return false;
        }

        public NodoCelda ObtenerInicio()
        {
            return inicio;
        }
        public ListaEnlazadaCelda Clonar()
        {
            ListaEnlazadaCelda nueva = new ListaEnlazadaCelda();

            NodoCelda actual = inicio;

            while (actual != null)
            {
                nueva.Insertar(new Celda(actual.Dato.Fila, actual.Dato.Columna));
                actual = actual.Siguiente;
            }

            return nueva;
        }

        public int GetTam()
        {
            return count;
        }
    }
}
