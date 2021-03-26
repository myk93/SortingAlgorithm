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
                while (swapped == true)
                {

                    // reset the swapped flag on entering the
                    // loop, because it might be true from a
                    // previous iteration.
                    swapped = false;

                    // loop from bottom to top same as
                    // the bubble sort
                    for (int i = start; i < end - 1; ++i)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            d.Invoke(() => Swap(arr, i, i + 1));
                            Thread.Sleep(pause);

                            swapped = true;
                        }
                    }

                    // if nothing moved, then array is sorted.
                    if (swapped == false)
                        break;

                    // otherwise, reset the swapped flag so that it
                    // can be used in the next stage
                    swapped = false;

                    // move the end point back by one, because
                    // item at the end is in its rightful spot
                    end = end - 1;

                    // from top to bottom, doing the
                    // same comparison as in the previous stage
                    for (int i = end - 1; i >= start; i--)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            d.Invoke(() => Swap(arr, i, i + 1));
                            Thread.Sleep(pause);
                            swapped = true;
                        }
                    }

                    // increase the starting point, because
                    // the last stage would have moved the next
                    // smallest number to its rightful spot.
                    start = start + 1;
                }
            });
           
            return 0;
        }
    }
}
