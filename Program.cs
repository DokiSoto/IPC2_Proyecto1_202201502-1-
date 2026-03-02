using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("===== LABORATORIO EPIDEMIOLÓGICO =====");
            Console.WriteLine("1. Cargar archivo XML");
            Console.WriteLine("2. Elegir paciente");
            Console.WriteLine("3. Ejecutar un período");
            Console.WriteLine("4. Ejecutar simulación automática");
            Console.WriteLine("5. Generar XML de salida");
            Console.WriteLine("6. Limpiar memoria");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            int.TryParse(Console.ReadLine(), out opcion);
        } while (opcion != 7);
    }
}
