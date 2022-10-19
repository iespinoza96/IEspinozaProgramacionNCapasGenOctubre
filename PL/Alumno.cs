using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Por favor ingrese los datos del alumno");
            Console.WriteLine("Nombre: ");
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Paterno: ");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Materno: ");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Fecha Nacimiento (yyyy-MM-dd): ");
            alumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Genero (M-F):  ");
            alumno.Genero = char.Parse(Console.ReadLine());

            BL.Alumno.Add(alumno);
        }
    }
}
