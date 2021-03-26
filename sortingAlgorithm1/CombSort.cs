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
        static int GetNextGap(int gap)
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
            pause *= 2;
            Task.Factory.StartNew(() =>
            {
                int n = arr.Count;
                int gap = n;
                bool swapped = true;

                while (gap != 1 || swapped == true)
                {
                    gap = GetNextGap(gap);
                    swapped = false;
                    for (int i = 0; i < n - gap; i++)
                    {
                        if (arr[i] > arr[i + gap])
                        {
                            d.Invoke(() => Swap(arr, i, i + gap));
                            Thread.Sleep(pause);
                            swapped = true;
                        }
                    }
                    Thread.Sleep(pause);

                }
            });
          
            return 1;
        }

    }
}
