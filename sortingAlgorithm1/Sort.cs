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
        //public Collection<int> arr { get; set; }
        public static Random rand = new Random();
        private bool isStop = false;

        protected int numOfSwap;
        protected int numOfTries;

        public bool IsStop { get => isStop; set => isStop = value; }

        /************************************************************************************/
        public abstract int DoSort(Collection<int> arr,Dispatcher d = null ,int pause = 0);

        /***********************************************************/
        public BaseSort()
        {
            numOfSwap = 0;
            numOfTries = 0;
        }

        protected bool IsSorted(Collection<int> arr)
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

        public int Maximum(Collection<int> arr)
        {
            int maximum = arr[0];
            for (int i = 1; i < arr.Count; i++)
                maximum = arr[i] > maximum ? arr[i] : maximum;
            return maximum;
        }
        public static void Shuffle(Collection<int> arr)
        {
            for (int i = 0; i < (arr.Count)*(arr.Count/70+1); i++)
            {
                BaseSort.Swap(arr,rand.Next(arr.Count), rand.Next(arr.Count));
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
        protected static void Swap(Collection<int> arr, int a,  int b)
        {
            
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        //public void Print()
        //{
        //    for (int i = 0; i < arr.Count; i++)
        //    {
        //      //  Console.Write(arr[i] + " ");
        //    }
        //    Console.WriteLine();
        //}
    }
    
}
