using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheTree
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Hello!");
            Console.Write("\nPlease, enter the amount of elements of the tree: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            MyTree tree = new MyTree();
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 100);
            }
            tree.beginOfFile();

            for (int i = 0; i < arr.Length; i++)
            {
                tree.Add(arr[i]);
            }

            Console.Write("\nThe amount of elements in the tree is: {0}", tree.Count);

            tree.doGetMinElRecur();

            Console.ReadKey();
        }
    }
}
