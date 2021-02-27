using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting_algorithm
{
    public abstract class BaseSort
    {
        protected int[] arr;
        protected int numOfSwap;
        protected int numOfTries;

        /************************************************************************************/
        public abstract void DoSort();

   
       

       
        /***********************************************************/

        public BaseSort()
        {
            arr = new int[100];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
            Shuffle();
            numOfSwap = 0;
            numOfTries = 0;
        }

        public BaseSort(int size)
        {
            arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
            Shuffle();
            numOfSwap = 0;
            numOfTries = 0;
        }

        protected bool IsSorted()
        {
            bool isSorted = true;
            for (int i = 0; i < arr.Length - 1 && isSorted; i++)
            {
                if (arr[i] > arr [i+1])
                {
                    isSorted = false;
                }
            }
            return isSorted;
        }

        protected void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                Swap(ref arr[rand.Next(arr.Length - 1)], ref arr[rand.Next(arr.Length - 1)]);
                numOfSwap++;
            }
        }

        protected void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
