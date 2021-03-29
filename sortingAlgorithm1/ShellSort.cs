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
    class ShellSort : BaseSort
    {

        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(()=>{
                int t = arr.Count / 2;
                while (t >= 1 && !IsStop)
                {
                    for (var i = t; i < arr.Count && !IsStop; i++)
                    {
                        var j = i;
                        while ((j >= t) && (arr[j - t] > arr[j]) && !IsStop)
                        {
                            d.Invoke(() => Swap(arr, j, j - t));
                            Thread.Sleep(pause);
                            j = j - t;
                        }
                    }

                    t = t / 2;
                }
            });
         

            return 1;
        }
    }
}

