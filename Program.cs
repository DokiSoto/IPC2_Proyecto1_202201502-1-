using System;


namespace IPC2PROYECTO1
{
    class Program
    {
        static void Main(string[] args)
        {
            ControladorSistema sistema = new ControladorSistema();
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

                switch (opcion)
                {
                    case 1:
                        sistema.CargarXML();
                        break;

                    case 2:
                        sistema.SeleccionarPaciente();
                        break;

                    case 3:
                        sistema.EjecutarUnPeriodo();
                        break;

                    case 4:
                        sistema.EjecutarAuto();
                        break;

                    case 5:
                        sistema.GenerarXML();
                        break;

                    case 6:
                        sistema.LimpiarMemoria();
                        break;

                    case 7:
                        Console.WriteLine("ADIOS");
                        break;

                    default:
                        Console.WriteLine("OPCION INVALIDA, ESCRIBS OTRA VEZ");
                        break;
                }
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 7);
        }
    }
}