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
    class CocktailSort : BaseSort
    {
        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
        {
            bool swapped = true;
            int start = 0;
            int end = arr.Count;
            Task.Factory.StartNew(() =>
            {
                pause /= 2;
                while (swapped == true && !IsStop)
                {

                    // reset the swapped flag on entering the
                    // loop, because it might be true from a
                    // previous iteration.
                    swapped = false;

                    // loop from bottom to top same as
                    // the bubble sort
                    for (int i = start; i < end - 1 && !IsStop; ++i)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            d.Invoke(() => Swap(arr, i, i + 1));
                            Thread.Sleep(pause);

                            swapped = true;
                        }
                    }
                    if (swapped == false)
                        break;
                    swapped = false;
                    end--; ;
                    for (int i = end - 1; i >= start && !IsStop; i--)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            d.Invoke(() => Swap(arr, i, i + 1));
                            Thread.Sleep(pause);
                            swapped = true;
                        }
                    }

                    start += + 1;
                }
            });
           
            return 0;
        }
    }
}
