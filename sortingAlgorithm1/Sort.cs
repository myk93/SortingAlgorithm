using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace Sorting_algorithm
{
    public abstract class BaseSort
    {
        //protected int[] arr;
        protected Collection<int> arr;

        protected int numOfSwap;
        protected int numOfTries;

        /************************************************************************************/
        public abstract void DoSort(Dispatcher d = null);



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
            for (int i = 0; i < arr.Count/2 + 1; i++)
            {
                Swap(rand.Next(arr.Count), rand.Next(arr.Count));
            }
        }

        //protected void Shuffle(Dispatcher d)
        //{
        //    Random rand = new Random();
        //    for (int i = 0; i < arr.Count/2+1; i++)
        //    {
        //        if (d != null)
        //        {
        //            d.Invoke(() => Swap(rand.Next(arr.Count), rand.Next(arr.Count)));
        //        }
        //        else
        //            Swap(rand.Next(arr.Count), rand.Next(arr.Count));
        //    }
        //    //Thread.Sleep(500);
        //}
        protected void Swap( int a,  int b)
        {
            numOfSwap++;
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
