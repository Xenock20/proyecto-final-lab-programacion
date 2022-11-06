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

        public void ingreseApellido()
        {
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                            INGRESE EL APELLIDO                                │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        public void ingreseEdad()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                              INGRESE LA EDAD                                  │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        public void ingreseDNI()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                              INGRESE EL DNI                                   │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        public void ingreseSexo()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                          INGRESE EL SEXO  (M o F)                             │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        public void finalIngreso()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                  PERSONA AGREGADA CORRACTAMENTE AL CENSO                      │");
            Console.WriteLine("│              Precione cualquier tecla para ingresar otra persona              │");
            Console.WriteLine("│              Si desea terminar el registro presione la tecla ESC              │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }
    }


    class Program
    {

        static private List<Persona> listaDePersonasCenso = new List<Persona>();
        static private List<Persona> listaOrdenada = new List<Persona>();
        static private List<Persona> listaMasculinaOrdenadaAlfa = new List<Persona>();
        static Mensajes msg = new Mensajes();
        static int numFinaly;


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
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
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
                    opcA();
                    break;

                case "B":
                    opcB();
                    break;

                case "C":
                    opcC();
                    break;

                case "D":
                    opcD();
                    break;

                case "E":
                    opcE();
                    break;

                case "F":
                    Salir();
                    break;

                default:
                    Console.Clear();
                    menu();
                    break;
            }

        }




        private static void opcA()
        {
            Console.WriteLine("\tAPELLIDO\t|\tNOMBRE\t|\tDNI\t|\tEDAD\t|\tSEXO\t");
            for (int i = 0; i <= listaDePersonasCenso.Count() - 1; i++)
            {
                Console.WriteLine("\t" + listaDePersonasCenso[i].apellido + "\t\t" + listaDePersonasCenso[i].nombre + "\t\t" + listaDePersonasCenso[i].dni + "\t\t" + listaDePersonasCenso[i].edad + "\t\t" + listaDePersonasCenso[i].sexo);
            }

        }

        private static void opcB()
        {
            listaOrdenada = listaDePersonasCenso;

            listaOrdenada.Sort(delegate (Persona x, Persona y)
            {
                return x.edad.CompareTo(y.edad);
            });

            Console.WriteLine("\tAPELLIDO\t|\tNOMBRE\t|\tEDAD\t");
            for (int i = 0; i <= listaOrdenada.Count() - 1; i++)
            {
                Console.WriteLine("\t" + listaOrdenada[i].apellido + "\t\t" + listaOrdenada[i].nombre + "\t\t" + listaOrdenada[i].edad + "\t\t");
            }
        }

        private static void opcC()
        {
            for (int i = 0; i <= listaDePersonasCenso.Count() - 1; i++)
            {
                if (listaDePersonasCenso[i].sexo == 'M')
                {
                    listaMasculinaOrdenadaAlfa.Add(listaDePersonasCenso[i]);
                }
            }

            listaMasculinaOrdenadaAlfa.Sort((x, y) => string.Compare(x.apellido, y.apellido));

            for (int i = 0; i <= listaMasculinaOrdenadaAlfa.Count() - 1; i++)
            {
                Console.WriteLine("\t" + listaMasculinaOrdenadaAlfa[i].apellido + "\t\t" + listaMasculinaOrdenadaAlfa[i].nombre + "\t\t" + listaMasculinaOrdenadaAlfa[i].edad);
            }
        }


        private static void opcD()
        {
            ulong dniB;

            Console.WriteLine("Ingrese el dni que esta buscando: ");
            dniB = ulong.Parse(Console.ReadLine());

            for (int i = 0; i <= listaDePersonasCenso.Count - 1; i++)
            {
                if (dniB == listaDePersonasCenso[i].dni)
                {
                    Console.WriteLine("\t" + listaDePersonasCenso[i].apellido + "\t\t" + listaDePersonasCenso[i].nombre + "\t\t" + listaDePersonasCenso[i].dni + "\t\t" + listaDePersonasCenso[i].edad + "\t\t" + listaDePersonasCenso[i].sexo);
                }
            }
        }

        private static void opcE()
        {
            string apellidoB;

            Console.WriteLine("Ingrese el apellido que esta buscando: ");
            apellidoB = Console.ReadLine();

            for (int i = 0; i <= listaDePersonasCenso.Count - 1; i++)
            {
                if (apellidoB == listaDePersonasCenso[i].apellido)
                {
                    Console.WriteLine("\t" + listaDePersonasCenso[i].apellido + "\t\t" + listaDePersonasCenso[i].nombre + "\t\t" + listaDePersonasCenso[i].dni + "\t\t" + listaDePersonasCenso[i].edad + "\t\t" + listaDePersonasCenso[i].sexo);
                }
            }
        }

        static public void ingreso()
        {
            Console.Clear();

            Persona ps = new Persona();

            msg.ingreseNombre();
            string fullName = Console.ReadLine();

            while (fullName.Length == 0 || fullName.Length > 30)
            {
                if (fullName.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             EL NOMBRE ESTA VACIO                              │");
                    msg.ingreseNombre();
                    fullName = Console.ReadLine();
                }
                else if (fullName.Length > 30)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                           SOLO HASTA 30 CARACTERES                            │");
                    msg.ingreseNombre();
                    fullName = Console.ReadLine();
                }
            }


            msg.ingreseApellido();
            string fullApellido = Console.ReadLine();

            while (fullApellido.Length == 0 || fullApellido.Length > 30)
            {
                if (fullApellido.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             EL APELLIDO ESTA VACIO                            │");
                    msg.ingreseApellido();
                    fullApellido = Console.ReadLine();
                }
                else if (fullApellido.Length > 30)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                           SOLO HASTA 30 CARACTERES                            │");
                    msg.ingreseApellido();
                    fullApellido = Console.ReadLine();
                }
            }


            msg.ingreseEdad();
            string edad = Console.ReadLine();

            while (edad.Length == 0 || !int.TryParse(edad, out numFinaly) || !(int.Parse(edad) >= 0 && int.Parse(edad) <= 99))
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

            while (dni.Length == 0 || (dni.Length < 7 || dni.Length > 8) || !int.TryParse(dni, out numFinaly))
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

            while (sexo.Length == 0 || !((sexo[0] == 'M' || sexo[0] == 'F') || (sexo[0] == 'm' || sexo[0] == 'f')))
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
            ps.apellido = fullApellido;
            ps.edad = int.Parse(edad);
            ps.dni = ulong.Parse(dni);
            ps.sexo = char.Parse(sexo);

            listaDePersonasCenso.Add(ps);

            msg.finalIngreso();
        }


        private static void Salir()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  Desea salir del programa?  ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  1- Si");
            Console.WriteLine("  2- No");
            Console.WriteLine("-----------------------------");
            Console.Write("  ingrese una opcion: ");
            string S = Console.ReadLine();

            if (!int.TryParse(S, out numFinaly))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("  Valor incorrecto  (precione enter para seguir)");
                Console.WriteLine("-------------------------------------------------");
                Console.ReadLine();
                Salir();
            }

            int s = int.Parse(S);

            if (s == 1)
            {
                Environment.Exit(0);
            }
            else if (s == 2)
            {
                menu();
            }
            else
            {
                Salir();
            }
        }
    }
}