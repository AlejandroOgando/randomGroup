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
            Console.Write("Introducirla ruta del archivo txt, que contenga los estudiantes: ");
            string filepath = Console.ReadLine();
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los grupos: ");
            string filepath1 = Console.ReadLine();
            Console.WriteLine("Introduzca la ruta del archivo txt, que contenga los temas: ");
            string filepath2 = Console.ReadLine();

            List<string> students = File.ReadAllLines(filepath).ToList();
            List<string> groups = File.ReadAllLines(filepath1).ToList();
            List<string> topics = File.ReadAllLines(filepath2).ToList();

            students = RandomList(students);
            groups = RandomList(groups);
            topics = RandomList(topics);

            float studentsAmount = students.Count() / groups.Count();
            float topicsAmount = topics.Count() / groups.Count();

            // Make an array for extras and make sure that no element is left out
            int[] students1 = new int[groups.Count()]; // {null,null,null,null,...null}
            for (int i = 0; i < students1.Length; i++)
            {
                students1[i] = 0; // {0,0,0,0,...0}
            }

            int[] topics1 = new int[groups.Count()];
            for (int i = 0; i < topics1.Length; i++)
            {
                topics1[i] = 0;
            }

            // Add extras to arrays
            int b = 0;
            while (((students.Count() - b) % groups.Count()) > 0)
            {
                students1[b] = 1;
                b++;
            }

            int c = 0;
            while (((topics.Count() - c) % groups.Count()) > 0)
            {
                topics1[c] = 1;
                c++;
            }

            // Print
            for (int i = 0; i < groups.Count(); i++)
            {
                Console.WriteLine("----------------");
                Console.WriteLine($"\n{groups[i]}");
                Console.WriteLine("----------------");

                Console.WriteLine("Integrantes:" + (studentsAmount + students1[i]));
                int e = 0;

                while (e < (studentsAmount + students1[i]))
                {
                    Console.WriteLine(students[0]);
                    students.RemoveAt(0);
                    e++;

                }

                Console.WriteLine("Cantidad de temas:" + (topicsAmount + topics1[i]));

                int t = 0;

                while (t < (topicsAmount + topics1[i]))
                {
                    Console.WriteLine(topics[0]);
                    topics.RemoveAt(0);
                    t++;
                }
            }
            Console.ReadKey();
        }
    }
}
