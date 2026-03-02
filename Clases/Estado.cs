using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2PROYECTO1.Clases
{
    public class Estado
    {
        public string Patron {  get; set; }
        public int Periodo { get; set; }

        public Estado(string patron, int periodo) 
        { 
            this.Patron = patron;
            this.Periodo = periodo;
        }
    }
}
