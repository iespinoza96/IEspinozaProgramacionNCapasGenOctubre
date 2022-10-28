using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Alumno.Add();
            //Alumno.GetAll();

            Console.WriteLine("Por favor seleccione una opcion");
            Console.WriteLine("1.- Agregar alumno");
            Console.WriteLine("2.- Mostrar alumnos");
            Console.WriteLine("3.- Mostrar alumno");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Alumno.Add();
                    Console.ReadKey();
                    break;
                case 2:
                    Alumno.GetAll();
                    Console.ReadKey();
                    break;
                case 3:
                    Alumno.GetById();
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine( "Opcion invalida");
                    break;
                    
            }
        }
    }
}
