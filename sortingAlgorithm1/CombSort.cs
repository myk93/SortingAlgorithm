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
    class CombSort:BaseSort
    {
        static int getNextGap(int gap)
        {
            // Shrink gap by Shrink factor
            gap = (gap * 10) / 13;
            if (gap < 1)
                return 1;
            return gap;
        }

        // Function to sort arr[] using Comb Sort
        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                int n = arr.Count;

                // initialize gap
                int gap = n;

                // Initialize swapped as true to 
                // make sure that loop runs
                bool swapped = true;

                // Keep running while gap is more than 
                // 1 and last iteration caused a swap
                while (gap != 1 || swapped == true)
                {
                    // Find next gap
                    gap = getNextGap(gap);

                    // Initialize swapped as false so that we can
                    // check if swap happened or not
                    swapped = false;

                    // Compare all elements with current gap
                    for (int i = 0; i < n - gap; i++)
                    {
                        if (arr[i] > arr[i + gap])
                        {
                            d.Invoke(() => Swap(arr, i, i + gap));
                            Thread.Sleep(pause);
                            // Set swapped
                            swapped = true;
                        }
                    }
                }
            });
          
            return 1;
        }

    }
}
