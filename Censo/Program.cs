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
        public ulong dni { get; set; }
    }

    public class Mensajes
    {
        public void ingreseNombre()
        {
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                             INGRESE EL NOMBRE                                 │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        public void ingreseEdad()
        {
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                              INGRESE LA EDAD                                  │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        public void ingreseDNI()
        {
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                              INGRESE EL DNI                                   │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        public void ingreseSexo()
        {
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                              INGRESE EL SEXO                                  │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }
    }


    class Program
    {

        static private List<Persona> listaDePersonasCenso = new List<Persona>();
        static Mensajes msg = new Mensajes();

        static void Main(string[] args)
        {
            do
            {
                ingreso();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Clear();

            menu();
            
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

        static public void ingreso()
        {
            Persona ps = new Persona();

            msg.ingreseNombre();
            string fullName = Console.ReadLine();

            while(fullName.Length == 0 || fullName.Length > 30)
            {
                if(fullName.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             EL NOMBRE ESTA VACIO                              │");
                    msg.ingreseNombre();
                    fullName = Console.ReadLine();
                } else if(fullName.Length > 30)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                           SOLO HASTA 30 CARACTERES                            │");
                    msg.ingreseNombre();
                    fullName = Console.ReadLine();
                }
            }


            msg.ingreseEdad();
            string edad = Console.ReadLine();

            while (edad.Length == 0 || !int.TryParse(edad, out int numFinaly) || !(int.Parse(edad) >= 0 && int.Parse(edad) <= 99))
            {
                if (edad.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             LA EDAD ESTA VACIO                                │");
                    msg.ingreseEdad();
                    edad = Console.ReadLine();
                }
                else if (!int.TryParse(edad, out numFinaly))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                               NO ES UN NUMERO                                 │");
                    msg.ingreseEdad();
                    edad = Console.ReadLine();
                }
                else if (!(int.Parse(edad) >= 0 && int.Parse(edad) <= 99))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                                 EDAD INVALIDA                                 │");
                    msg.ingreseEdad();
                    edad = Console.ReadLine();
                }
            }


            msg.ingreseDNI();
            string dni = Console.ReadLine();

            while (dni.Length == 0 || (dni.Length < 7 || dni.Length > 8) || !int.TryParse(dni, out int numFinaly))
            {
                if (dni.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             EL DNI ESTA VACIO                                 │");
                    msg.ingreseDNI();
                    dni = Console.ReadLine();
                }
                else if ((dni.Length < 7 || dni.Length > 8))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                           SOLO HASTA 7 o 8 DIGITOS                            │");
                    msg.ingreseDNI();
                    dni = Console.ReadLine();
                }
                else if (!int.TryParse(dni, out numFinaly))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                           NO ES UN NUMERO                                     │");
                    msg.ingreseDNI();
                    dni = Console.ReadLine();
                }
            }


            msg.ingreseSexo();
            string sexo = Console.ReadLine();

            while (sexo.Length == 0 || !(sexo[0] == 'm' || sexo[0] == 'f'))
            {
                if (sexo.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             EL VALOR ESTA VACIO                               │");
                    msg.ingreseSexo();
                    sexo = Console.ReadLine();
                }
                else if (!(sexo[0] == 'm' || sexo[0] == 'f'))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                     SOLO VALOR M (MASCULINO) O F (FEMENINO)                   │");
                    msg.ingreseSexo();
                    sexo = Console.ReadLine();
                }
            }

            ps.nombre = fullName;
            ps.edad = int.Parse(edad);
            ps.dni = ulong.Parse(dni);
            ps.sexo = char.Parse(sexo);

            listaDePersonasCenso.Add(ps);
        }
    }
}