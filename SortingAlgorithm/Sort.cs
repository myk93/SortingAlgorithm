﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
namespace Sorting_algorithm
{
    public abstract class BaseSort
    {
        //protected int[] arr;
        protected Collection<int> arr;

        protected int numOfSwap;
        protected int numOfTries;

        /************************************************************************************/
        public abstract void DoSort();

   
            
        /***********************************************************/

        public BaseSort()
        {
            arr = new Collection<int>(); ;
            for (int i = 0; i < 15; i++)
            {
                arr[i] = i + 1;
            }
            Shuffle();
            numOfSwap = 0;
            numOfTries = 0;
        }

        public BaseSort(Collection<int> collection)
        {
            arr = collection;
            Shuffle();
            numOfSwap = 0;
            numOfTries = 0;
        }

        public BaseSort(int size)
        {
            arr = new Collection<int>(); ;
            for (int i = 0; i < size; i++)
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
            
            for (int i = 0; i < arr.Count - 1 && isSorted; i++)
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
            for (int i = 0; i < arr.Count; i++)
            {
                Swap( rand.Next(arr.Count - 1), rand.Next(arr.Count - 1));
            }
        }

        protected void Swap( int a,  int b)
        {
            numOfSwap++;
            
            Thread.Sleep(500);
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public void Print()
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
