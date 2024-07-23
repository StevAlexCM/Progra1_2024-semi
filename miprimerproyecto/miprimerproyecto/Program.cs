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
            Console.WriteLine("num1: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("num2: ");
            int num2 = int.Parse(Console.ReadLine());

            int respuesta = num1 + num2;
            Console.WriteLine("Su respuesta es {2}",num1,num2, respuesta);

            Console.ReadLine();
        }
    }
}
