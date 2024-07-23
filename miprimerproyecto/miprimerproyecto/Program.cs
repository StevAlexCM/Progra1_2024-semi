using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miprimerproyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean comprobar = true;
            Console.WriteLine("el valor es {0}", comprobar);

            Console.WriteLine("nombre: ");
            string nombre = Console.ReadLine();
                Console.WriteLine("hola {0} bienvenido", nombre);

            Console.ReadLine();

            DateTime fechaActual = new DateTime();
            Console.WriteLine("la fecha actual es {0} ", fechaActual);
            Console.ReadLine();

        }
    }
}
