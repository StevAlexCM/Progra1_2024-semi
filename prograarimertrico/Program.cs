﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prograarimertrico
{
    class Program
    {
        static void Main(string[] args)
        {
            //prioridad de los operadors arimetricos.
            //ejercicio obtener el promedio de una serie de numeros

            int[] serie = new int[] { 5, 4, 6, 8, 9 }; //32
            int suma = 0;
            foreach (int num in serie) { suma = suma + num; }
            decimal prom = suma / serie.Length;
            Console.WriteLine("La suma es: {0}, el promedio es {1}", suma, prom);

            Console.ReadLine();

        }
    }
}
