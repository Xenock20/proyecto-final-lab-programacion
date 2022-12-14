using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            menu();

            Console.ReadKey();
        }

        static public void menu()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                               │");
            Console.WriteLine("│                    SISTEMA DE CENSO-CIUDAD DE BUENOS AIRES                    │");
            Console.WriteLine("│                                                                               │");
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│    A. Listado de todas las personas ingresadas.                               │");
            Console.WriteLine("│    B. Listado de personas ordenadas por edad de menor a mayor.                │");
            Console.WriteLine("│    C. Lista de personas masculinas ordenados alfabeticamente (apellido).      │");
            Console.WriteLine("│    D. Buscar por DNI.                                                         │");
            Console.WriteLine("│    E. Buscar por apellido.                                                    │");
            Console.WriteLine("│    F. Salir del sistema.                                                      │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
            Console.Write("Ingrese una opcion: ");
            string opc = Console.ReadLine();


            switch (opc.ToUpper())
            {
                case "A":
                    Console.Clear();
                    opcA();
                    Console.ReadLine();
                    menu();
                    break;

                case "B":
                    Console.Clear();
                    opcB();
                    Console.ReadLine();
                    menu();
                    break;

                case "C":
                    Console.Clear();
                    opcC();
                    Console.ReadLine();
                    menu();
                    break;

                case "D":
                    Console.Clear();
                    opcD();
                    Console.ReadLine();
                    menu();
                    break;

                case "E":
                    Console.Clear();
                    opcE();
                    Console.ReadLine();
                    menu();
                    break;

                case "F":
                    Console.Clear();
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
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("│                         LISTA DE TODAS LAS PERSONAS INGRESADAS                           │");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("├──────────────────────────────┬──────────────────────────────┬──────────┬────────┬────────┤");
            Console.WriteLine("|           APELLIDO           |            NOMBRE            |    DNI   |  EDAD  |  SEXO  |");

            for (int i = 0; i <= listaDePersonasCenso.Count() - 1; i++)
            {
                Console.WriteLine("├──────────────────────────────┼──────────────────────────────┼──────────┼────────┼────────┤");
                Console.WriteLine(rowList(listaDePersonasCenso[i], "A"));
            }

            Console.WriteLine("└──────────────────────────────┴──────────────────────────────┴──────────┴────────┴────────┘");
            Console.WriteLine("       *************** PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU **************          ");

        }


        private static void opcB()
        {
            listaOrdenada = listaDePersonasCenso;

            listaOrdenada.Sort(delegate (Persona x, Persona y)
            {
                return x.edad.CompareTo(y.edad);
            });
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                      │");
            Console.WriteLine("│ LISTA DE LAS PERSONAS INGRESADAS ORDENADAS POR EDAD DE MENOR A MAYOR │");
            Console.WriteLine("│                                                                      │");
            Console.WriteLine("├──────────────────────────────┬──────────────────────────────┬────────┤");
            Console.WriteLine("|           APELLIDO           |            NOMBRE            |  EDAD  |");

            for (int i = 0; i <= listaOrdenada.Count() - 1; i++)
            {
                Console.WriteLine("├──────────────────────────────┼──────────────────────────────┼────────┤");
                Console.WriteLine(rowList(listaOrdenada[i], "B"));
            }

            Console.WriteLine("└──────────────────────────────┴──────────────────────────────┴────────┘");
            Console.WriteLine("    ********** PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU ********    ");
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

            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("│    LISTA DE TODAS LAS PERSONAS INGRESADAS DEL SEXO MASCULINO ORDENADA ALFABETICAMENTE    │");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("├──────────────────────────────┬──────────────────────────────┬──────────┬────────┬────────┤");
            Console.WriteLine("|           APELLIDO           |            NOMBRE            |    DNI   |  EDAD  |  SEXO  |");

            for (int i = 0; i <= listaMasculinaOrdenadaAlfa.Count() - 1; i++)
            {
                Console.WriteLine("├──────────────────────────────┼──────────────────────────────┼──────────┼────────┼────────┤");
                Console.WriteLine(rowList(listaMasculinaOrdenadaAlfa[i], "A"));
            }

            Console.WriteLine("└──────────────────────────────┴──────────────────────────────┴──────────┴────────┴────────┘");
            Console.WriteLine("       *************** PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU **************          ");
        }


        private static void opcD()
        {
            string dniB;

            Console.Write("INGRESE EL DNI QUE ESTA BUSCANDO: ");
            dniB = Console.ReadLine();

            while (dniB.Length == 0 || (dniB.Length < 7 || dniB.Length > 8) || !int.TryParse(dniB, out numFinaly))
            {
                if (dniB.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             EL DNI ESTA VACIO                                 │");
                    Console.Write("INGRESE EL DNI QUE ESTA BUSCANDO: ");
                    dniB = Console.ReadLine();
                }
                else if ((dniB.Length < 7 || dniB.Length > 8))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                          SOLO HASTA 7 o 8 DIGITOS                             │");
                    Console.Write("INGRESE EL DNI QUE ESTA BUSCANDO: ");
                    dniB = Console.ReadLine();
                }
                else if (!int.TryParse(dniB, out numFinaly))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                               NO ES UN NUMERO                                 │");
                    Console.Write("INGRESE EL DNI QUE ESTA BUSCANDO: ");
                    dniB = Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("│                                    BUSQUEDA POR DNI                                      │");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("├──────────────────────────────┬──────────────────────────────┬──────────┬────────┬────────┤");
            Console.WriteLine("|           APELLIDO           |            NOMBRE            |    DNI   |  EDAD  |  SEXO  |");

            if (dniExiste(dniB.ToString()))
            {
                for (int i = 0; i <= listaDePersonasCenso.Count - 1; i++)
                {
                    if (ulong.Parse(dniB) == listaDePersonasCenso[i].dni)
                    {
                        Console.WriteLine("├──────────────────────────────┼──────────────────────────────┼──────────┼────────┼────────┤");
                        Console.WriteLine(rowList(listaDePersonasCenso[i], "A"));
                        break;
                    }
                }
                Console.WriteLine("└──────────────────────────────┴──────────────────────────────┴──────────┴────────┴────────┘");
            }
            else
            {
                Console.WriteLine("├──────────────────────────────┴──────────────────────────────┴──────────┴────────┴────────┤");
                Console.WriteLine("│                                   DNI NO ENCOTRADO                                       │");
                Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────┘");
            }

            Console.WriteLine("       *************** PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU **************          ");
        }

        private static void opcE()
        {
            string apellidoB;

            Console.WriteLine("INGRESE EL APELLIDO QUE ESTA BUSCANDO: ");
            apellidoB = Console.ReadLine().ToUpper();


            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("│                         LISTA DE TODAS LAS PERSONAS INGRESADAS                           │");
            Console.WriteLine("│                                                                                          │");
            Console.WriteLine("├──────────────────────────────┬──────────────────────────────┬──────────┬────────┬────────┤");
            Console.WriteLine("|           APELLIDO           |            NOMBRE            |    DNI   |  EDAD  |  SEXO  |");

            

            if (apellidoExiste(apellidoB))
            {
                for (int i = 0; i <= listaDePersonasCenso.Count - 1; i++)
                {
                    if (apellidoB == listaDePersonasCenso[i].apellido.ToUpper())
                    {
                        Console.WriteLine("├──────────────────────────────┼──────────────────────────────┼──────────┼────────┼────────┤");
                        Console.WriteLine(rowList(listaDePersonasCenso[i], "A"));
                    }
                }
                Console.WriteLine("└──────────────────────────────┴──────────────────────────────┴──────────┴────────┴────────┘");
            }
            else
            {
                Console.WriteLine("├──────────────────────────────┴──────────────────────────────┴──────────┴────────┴────────┤");
                Console.WriteLine("│                                   APELLIDO NO ENCOTRADO                                  │");
                Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────┘");
            }

            Console.WriteLine("       *************** PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU **************          ");
        }

        private static string rowList(Persona persona, string v)
        {
            string row = "|";
            int numeroDeEspacios = 0;
            int mitadDeNumDeEspacio = numeroDeEspacios / 2;

            switch (v)
            {
                case "A":
                    numeroDeEspacios = 30 - persona.apellido.Length;

                    for (int i = 0; i <= numeroDeEspacios; i++)
                    {
                        if (i == mitadDeNumDeEspacio)
                        {
                            row += persona.apellido;
                            continue;
                        }

                        row += " ";
                    }

                    row += "|";

                    numeroDeEspacios = 30 - persona.nombre.Length;

                    for (int i = 0; i <= numeroDeEspacios; i++)
                    {
                        if (i == mitadDeNumDeEspacio)
                        {
                            row += persona.nombre;
                            continue;
                        }

                        row += " ";
                    }

                    row += "|";

                    if ((persona.dni.ToString()).Length == 7)
                    {
                        row += (" " + persona.dni + "  ");
                    }
                    else
                    {
                        row += (" " + persona.dni + " ");
                    }
                    row += "|";

                    if ((persona.edad.ToString()).Length == 1)
                    {
                        row += ("   " + persona.edad + "    ");
                    }
                    else
                    {
                        row += ("   " + persona.edad + "   ");
                    }
                    row += ("|   " + persona.sexo + "    |");

                    return row;

                case "B":

                    numeroDeEspacios = 30 - persona.apellido.Length;

                    for (int i = 0; i <= numeroDeEspacios; i++)
                    {
                        if (i == mitadDeNumDeEspacio)
                        {
                            row += persona.apellido;
                            continue;
                        }

                        row += " ";
                    }

                    row += "|";

                    numeroDeEspacios = 30 - persona.nombre.Length;

                    for (int i = 0; i <= numeroDeEspacios; i++)
                    {
                        if (i == mitadDeNumDeEspacio)
                        {
                            row += persona.nombre;
                            continue;
                        }

                        row += " ";
                    }

                    row += "|";

                    if ((persona.edad.ToString()).Length == 1)
                    {
                        row += ("   " + persona.edad + "    |");
                    }
                    else
                    {
                        row += ("   " + persona.edad + "   |");
                    }

                    return row;
            }

            return row;
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

            Console.Clear();
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

            Console.Clear();
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


            Console.Clear();
            msg.ingreseDNI();
            string dni = Console.ReadLine();

            while (dni.Length == 0 || (dni.Length < 7 || dni.Length > 8) || !int.TryParse(dni, out numFinaly) || dniExiste(dni))
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
                    Console.WriteLine("│                          SOLO HASTA 7 o 8 DIGITOS                             │");
                    msg.ingreseDNI();
                    dni = Console.ReadLine();
                }
                else if (!int.TryParse(dni, out numFinaly))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                               NO ES UN NUMERO                                 │");
                    msg.ingreseDNI();
                    dni = Console.ReadLine();
                } else if (dniExiste(dni))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                        ESTE DNI YA ENCUENTRA INGRESADO                        │");
                    msg.ingreseDNI();
                    dni = Console.ReadLine();
                }
            }


            Console.Clear();
            msg.ingreseSexo();
            string sexo = Console.ReadLine().ToUpper();

            while (sexo.Length == 0 || !((sexo[0] == 'M' || sexo[0] == 'F') || (sexo[0] == 'm' || sexo[0] == 'f')))
            {
                if (sexo.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             EL VALOR ESTA VACIO                               │");
                    msg.ingreseSexo();
                    sexo = Console.ReadLine().ToUpper();
                }
                else if (!(sexo[0] == 'm' || sexo[0] == 'f'))
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                     SOLO VALOR M (MASCULINO) O F (FEMENINO)                   │");
                    msg.ingreseSexo();
                    sexo = Console.ReadLine().ToUpper();
                }
            }

            ps.nombre = fullName;
            ps.apellido = fullApellido;
            ps.edad = int.Parse(edad);
            ps.dni = ulong.Parse(dni);
            ps.sexo = sexo[0];

            listaDePersonasCenso.Add(ps);

            msg.finalIngreso();
        }

        private static bool dniExiste(string dni)
        {
            for (int i = 0; i <= listaDePersonasCenso.Count - 1; i++)
            {
                if(ulong.Parse(dni) == listaDePersonasCenso[i].dni)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool apellidoExiste(string? apellidoB)
        {
            for (int i = 0; i <= listaDePersonasCenso.Count - 1; i++)
            {
                if (apellidoB == listaDePersonasCenso[i].apellido.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }

        private static void Salir()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                          DESEA SALIR DEL PROGRAMA?                            │");
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                          1- SI                                                │");
            Console.WriteLine("│                          2- NO                                                │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");

            Console.Write("  ingrese una opcion: ");
            string S = Console.ReadLine();

            if (!int.TryParse(S, out numFinaly))
            {
                Console.Clear();
                Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│          VALOR INCORRECTO (PRECIONE CUALQUIER TECLA PARA SEGUIR)              │");
                Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
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