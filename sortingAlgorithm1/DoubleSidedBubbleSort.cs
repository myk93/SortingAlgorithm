using Sorting_algorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace sortingAlgorithm1
{
    public class DoubleSidedSelectionSort : BaseSort
    {
        public DoubleSidedSelectionSort() : base()
        { }
        public DoubleSidedSelectionSort(int size) : base(size)
        { }
        public DoubleSidedSelectionSort(Collection<int> size) : base(size)
        { }
        public override int DoSort(Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                int smallIndex ;
                int highestIndex ;
                int t = arr.Count-1;
            for (int i = 0; i < arr.Count / 2 ; i++)
            {
                smallIndex = i;
                highestIndex = arr.Count - i -1;
                for (int j = i; j < t; j++)
                {
                    if (arr[j] < arr[smallIndex])
                    {
                        smallIndex = j;
                    }
                    if (arr[j] > arr[highestIndex])
                    {
                        highestIndex = j;
                    }

                }
                t--;
                d.Invoke(() => 
                {
                    Swap(i, smallIndex);
                    Swap(arr.Count - i - 1, highestIndex);
                });
                    Thread.Sleep(10);
                  

                }
            }
            );
            return 0;
        }
    }
}
