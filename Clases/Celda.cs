using System;


namespace IPC2PROYECTO1.Clases
{
    public class Celda
    {
        public int Fila {  get; set; }
        public int Columna { get; set; }    

        public Celda(int fila, int columna)
        {
            this.Fila = fila;
            this.Columna = columna;
        }

        public override string ToString()
        {
            return Fila + ","+ Columna;
        }
    }
}
