using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
//using System.Windows.Threading;

namespace Sorting_algorithm
{
    public class BubbleSort : BaseSort
    {
        public BubbleSort() : base()
        {
        }

        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
        {
           // pause /= pause;
            Task.Factory.StartNew(() =>
                {
                    bool IsSorted;
                    for (int i = arr.Count - 1; (i >= 1) && !IsStop; i--)
                    {
                        IsSorted = true;
                        for (int j = 0; j < i && !IsStop; j++)
                        {
                            if (arr[j] > arr[j + 1])
                            {
                                d.Invoke(() => Swap(arr, j, j + 1));
                                Thread.Sleep(1);
                                IsSorted = false;
                            }
                        }
                        if (IsSorted)
                        {
                            break;
                        }
                    }
                }
            );
            return numOfSwap;
        }
    }
}
