using System;
using Sorting_algorithm;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseSort sort = new BogoSort (15);
            //sort.DoSort();
            Console.WriteLine("Hello World!");
            sort.Print();
        }
    }
}
