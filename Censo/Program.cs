using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace censo
{

    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public char sexo { get; set; }
        public int edad { get; set; }
        public long dni { get; set; }
    }


    class Program
    {

        List<Persona> listaDePersonasCenso = new List<Persona>();

        static void Main(string[] args)
        {

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                menu();
            }

            Console.ReadKey();
        }

        static public void menu()
        {

            Console.WriteLine("┌┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                               │");
            Console.WriteLine("│                    SISTEMA DE CENSO-CIUDAD DE BUENOS AIRES                    │");
            Console.WriteLine("│                                                                               │");
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│    A. Listado de todas las personas ingresadas.                               │");
            Console.WriteLine("│    B. Listado de personas ordenadas por edad de menor a mayor.                │");
            Console.WriteLine("│    C. Lista de personas masculinas ordenados alfabeticamente.                 │");
            Console.WriteLine("│    D. Buscar por DNI.                                                         │");
            Console.WriteLine("│    E. Buscar por apellido.                                                    │");
            Console.WriteLine("│    F. Salir del sistema.                                                      │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
            Console.Write("Ingrese una opcion: ");
            string opc = Console.ReadLine();



            switch (opc.ToUpper())
            {
                case "A":
                    break;

                case "B":
                    break;

                case "C":
                    break;

                case "D":
                    break;

                case "E":
                    break;

                case "F":
                    break;

                default:
                    Console.Clear();
                    menu();
                    break;
            }

        }
    }
}