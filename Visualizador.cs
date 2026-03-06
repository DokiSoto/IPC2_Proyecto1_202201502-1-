using IPC2PROYECTO1.Clases;


namespace IPC2PROYECTO1
{
    public class Visualizador
    {
        public void ImprimirRejilla(Paciente paciente)
        {
            int minFila = int.MaxValue;
            int maxFila = int.MinValue;
            int minCol = int.MaxValue;
            int maxCol = int.MinValue;

            NodoCelda actual = paciente.CeldasVivas.ObtenerInicio();

            while (actual != null)
            {
                if (actual.Dato.Fila < minFila) minFila = actual.Dato.Fila;
                if (actual.Dato.Fila > maxFila) maxFila = actual.Dato.Fila;
                if (actual.Dato.Columna < minCol) minCol = actual.Dato.Columna;
                if (actual.Dato.Columna > maxCol) maxCol = actual.Dato.Columna;

                actual = actual.Siguiente;
            }

            for (int i = minFila; i <= maxFila; i++)
            {
                for (int j = minCol; j <= maxCol; j++)
                {
                    if (paciente.CeldasVivas.Existe(i, j))
                        Console.Write("X ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
        }
    }
}
