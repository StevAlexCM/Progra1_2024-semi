using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial1c2
{
    class Program
    {
        static void Main(string[] args)
        {

            var conversion = new Dictionary<string, double>
        {
            { "Pie Cuadrado", 0.0929 },
            { "Vara Cuadrada",  0.698896  },
            { "Yardas cuadrada", 0.836127 },
            { "Metro cuadrado", 1 },
            { "Tareas", 1000 },
            { "Manzana", 7050 },
            { "Hectarea", 10000 }
        };
            Console.Clear();
            var unidades = new List<string>(conversion.Keys);


            Console.WriteLine("Seleccione el dato de entrada:");
            mostraropciones(unidades);

            int Entrada = Convert.ToInt32(Console.ReadLine()) - 1;
            
            Console.WriteLine("Conversor de Volumen: ");
            Console.WriteLine("Ingrese la cantidad a convertir: ");
            double cantidad = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Seleciones el dato de salida:");
            mostraropciones(unidades);

            int Salida = Convert.ToInt32(Console.ReadLine()) - 1;

            string entrada = unidades[Entrada];
            string salida = unidades[Salida];

            double resultado = cantidad * conversion[entrada] / conversion[salida];

            Console.WriteLine($"La cantidad de {cantidad} {entrada} es equivalente a {resultado} {salida}.");
            Console.ReadLine();
            return;
        } 
        static void mostraropciones(List<string>opciones)
        {
            for (int i = 0; i <opciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i]}");
            }
        }
    }
}
