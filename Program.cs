using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namePicker
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los estudiantes:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los grupos:");
            string filePath1 = Console.ReadLine();
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los temas:");
            string filePath2 = Console.ReadLine();

            List<string> estudiantes = File.ReadAllLines(filePath).ToList();
            List<string> grupos = File.ReadAllLines(filePath1).ToList();
            List<string> temas = File.ReadAllLines(filePath2).ToList();

            estudiantes = RandomList(estudiantes);
            grupos = RandomList(grupos);
            temas = RandomList(temas);

            float cantidadEstudiantes = estudiantes.Count() / grupos.Count();
            float cantidadTemas = temas.Count() / grupos.Count();

            for(int i = 0; i < grupos.Count(); i++)
            {
                Console.WriteLine($"\n{grupos[i]}");

                Console.WriteLine("Integrantes: " + cantidadEstudiantes);
                int e = 0;
                while (e < cantidadEstudiantes)
                {
                    Console.WriteLine(estudiantes[0]);
                    estudiantes.RemoveAt(0);
                    e++;
                }

               Console.WriteLine("Cantidad de Temas: " + cantidadTemas);
                int t = 0;
                while(t < cantidadTemas)
                {
                    Console.WriteLine(temas[0]);
                    temas.RemoveAt(0);
                    t++;
                }
            }
            Console.ReadLine();
        }

        static List<string> RandomList(List<string> array)
        {
            Random random = new Random();
            List<string> randomList = new List<string>();

            do
            {
                int posicion = random.Next(array.Count());
                randomList.Add(array[posicion]);
                array.RemoveAt(posicion);
            } while (array.Count() > 0);

            return randomList;
        }
    }
}
