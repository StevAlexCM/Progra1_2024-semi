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
            Console.WriteLine("Num1: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Num2: ");

            double num2 = double.Parse(Console.ReadLine());

         double respuesta = num1 + num2;
            Console.WriteLine("La respuesta de la suma es, {2}", num1, num2, respuesta);

            Console.ReadLine();

        }
    }
}
