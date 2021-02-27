using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting_algorithm
{
    class BubbleSort :BaseSort
    {
        public BubbleSort() : base()
        {}
        public BubbleSort(int size) : base(size)
        { }
        public override void DoSort()
        {
            bool IsSorted;
            for (int i = arr.Length - 1; (i >= 1); i--)
            {
                IsSorted = true;
                numOfTries++;
                for (int j = 0; j < i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Print();
                        Swap(ref arr[j], ref arr[j + 1]);
                        numOfSwap++;
                        IsSorted = false;
                    }
                }
                if (IsSorted)
                {
                    break;
                }
            }
        }
    }
}
