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
          
            int[] serie = new int[] { 5, 9, 4, 6, 3, 2, 7, 11, 15, 17, 21 };
            foreach (int num in serie)
            {
                Console.WriteLine("El num {0} es {1}", num, num % 2 == 0 ? "Par" : "Impar");
                int i = 1,
                    n = 0;
                while (i <= num && n <= 2)
                {
                    if (num % i == 0)
                    {
                        n++;
                    }
                    i++; 
                Console.WriteLine("EL numero {0} {1}", num, n <= 2 ? "es primo" : "NO es primo");
            }
            Console.ReadLine();
        }
    }
}
