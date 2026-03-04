using IPC2PROYECTO1.Clases;
using IPC2PROYECTO1.ListasEnlazadas;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2PROYECTO1
{
    public class Simulador
    {
        public void EjecutarUnPeriodo(Paciente paciente)
        {
            ListaEnlazadaCelda nuevasCeldas = new ListaEnlazadaCelda();

            NodoCelda actual = paciente.CeldasVivas.ObtenerInicio();

            while (actual != null)
            {
                int fila = actual.Dato.Fila;
                int columna = actual.Dato.Columna;

                int vecinos = ContarVecinos(paciente, fila, columna);

                if (vecinos == 2 || vecinos == 3)
                {
                    nuevasCeldas.Insertar(new Celda(fila, columna));
                }

                actual = actual.Siguiente;
            }

            RevisarNacimientos(paciente, nuevasCeldas);

            paciente.CeldasVivas = nuevasCeldas;
        }

        private int ContarVecinos(Paciente paciente, int fila, int columna)
        {
            int contador = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int nuevaFila = fila + i;
                    int nuevaColumna = columna + j;

                    if (paciente.CeldasVivas.Existe(nuevaFila, nuevaColumna))
                        contador++;
                }
            }

            return contador;
        }

        private void RevisarNacimientos(Paciente paciente, ListaEnlazadaCelda nuevasCeldas)
        {
            NodoCelda actual = paciente.CeldasVivas.ObtenerInicio();

            while (actual != null)
            {
                int fila = actual.Dato.Fila;
                int columna = actual.Dato.Columna;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int nuevaFila = fila + i;
                        int nuevaColumna = columna + j;

                        if (!paciente.CeldasVivas.Existe(nuevaFila, nuevaColumna))
                        {
                            int vecinos = ContarVecinos(paciente, nuevaFila, nuevaColumna);

                            if (vecinos == 3)
                            {
                                if (!nuevasCeldas.Existe(nuevaFila, nuevaColumna))
                                {
                                    nuevasCeldas.Insertar(new Celda(nuevaFila, nuevaColumna));
                                }
                            }
                        }
                    }
                }

                actual = actual.Siguiente;
            }
        }
    }
}
