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

        //Alejandro J. Ogando. ID: 1096182
        //Marcos Yepez. ID: 1090192
        //Nayely Ventura. ID: 1094588
        //Bryan M. Medina. ID: 1094168
        //Héctor Soriano. ID: 1088434
        //Ian R. De los Santos. ID: 1095250

        //this method works with the random list
        static List<string> RandomList(List<string> array)
        {
            Random random = new Random();
            List<string> randomList = new List<string>();

            do
            {
                int position = random.Next(array.Count());
                randomList.Add(array[position]);
                array.RemoveAt(position);
            } while (array.Count() > 0);

            return randomList;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los estudiantes:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los grupos:");
            string filePath1 = Console.ReadLine();
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los temas:");
            string filePath2 = Console.ReadLine();

            List<string> students = File.ReadAllLines(filePath).ToList();
            List<string> groups = File.ReadAllLines(filePath1).ToList();
            List<string> topics = File.ReadAllLines(filePath2).ToList();

            students = RandomList(students);
            groups = RandomList(groups);
            topics = RandomList(topics);

            float studentsAmount = students.Count() / groups.Count();
            float topicsAmount = topics.Count() / groups.Count();

            for(int i = 0; i < groups.Count(); i++)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"\n{groups[i]}");
                Console.WriteLine("------------------------------");

                Console.WriteLine("Integrantes: " + studentsAmount);
                int e = 0;
                while (e < studentsAmount)
                {
                    Console.WriteLine(students[0]);
                    students.RemoveAt(0);
                    e++;
                }

               Console.WriteLine("Cantidad de Temas: " + topicsAmount);
                int t = 0;
                while(t < topicsAmount)
                {
                    Console.WriteLine(topics[0]);
                    topics.RemoveAt(0);
                    t++;
                }
            }

            Console.ReadLine();
        }

    }
}
