using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computoylaboratorio
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] serie = new int[] { 5, 4, 6, 8, 9 };
            int suma = 0;
            foreach (int num in serie)

                suma += num;
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            if (edad >= 18)

                Console.WriteLine("Bienvenido al mundo de las reposabilidades.");

            if (edad < 18)

                Console.WriteLine("Eres un adolescente, disfruta de la vida.");


            decimal prom = suma / serie.Length;
            Console.WriteLine("La suma es: {0}, el promedio {1}", suma, prom);

            Console.ReadLine();
        }
    }
}
