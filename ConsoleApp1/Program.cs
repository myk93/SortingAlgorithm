using System;
using Sorting_algorithm;
using sortingAlgorithm;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseSort sort = new MergeSort(15);
            sort.DoSort();
            Console.WriteLine("Hello World!");
            sort.Print();
        }
    }
}
