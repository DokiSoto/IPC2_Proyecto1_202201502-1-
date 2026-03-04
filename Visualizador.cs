using IPC2PROYECTO1.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2PROYECTO1
{
    public class Visualizador
    {
        public void ImprimirRejilla(Paciente paciente)
        {
            int maxFila = ObtenerMaxFila(paciente);
            int maxColumna = ObtenerMaxColumna(paciente);

            for (int i = 0; i <= maxFila; i++)
            {
                for (int j = 0; j <= maxColumna; j++)
                {
                    if (paciente.CeldasVivas.Existe(i, j))
                        Console.WriteLine("X ");
                    else
                        Console.WriteLine(". ");



                }
                Console.WriteLine();

            }
        }
        private int ObtenerMaxFila(Paciente paciente)
        {
            int max = 0;
            NodoCelda actual = paciente.CeldasVivas.ObtenerInicio();

            while (actual != null)
            {
                if (actual.Dato.Fila > max)
                    max = actual.Dato.Fila;

                actual = actual.Siguiente;
            }
            return max + 1;
        }


        private int ObtenerMaxColumna(Paciente paciente)
        {
            int max = 0;
            NodoCelda actual = paciente.CeldasVivas.ObtenerInicio();

            while (actual != null)
            {
                if (actual.Dato.Columna > max)
                    max = actual.Dato.Columna;

                actual = actual.Siguiente;
            }
            return max + 1;
        }
    }
}
