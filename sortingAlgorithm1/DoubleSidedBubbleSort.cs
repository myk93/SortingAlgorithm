using Sorting_algorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace sortingAlgorithm
{
    public class DoubleSidedSelectionSort : BaseSort
    {
        public DoubleSidedSelectionSort() : base()
        { }

        public override int DoSort(Collection<int> arr,Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0, j = arr.Count - 1; i < j; i++, j--)
                {
                    int min = arr[i], max = arr[i];
                    int min_i = i, max_i = i;
                    for (int k = i; k <= j; k++)
                    {
                        if (arr[k] > max)
                        {
                            max = arr[k];
                            max_i = k;
                        }

                        else if (arr[k] < min)
                        {
                            min = arr[k];
                            min_i = k;
                        }
                    }

                    d.Invoke(() => Swap(arr,i, min_i));
                    Thread.Sleep(pause);
                      if (arr[min_i] == max)
                    {
                        d.Invoke(() => Swap(arr,j, min_i));
                        Thread.Sleep(pause);

                    }
                    else
                    {
                        d.Invoke(() => Swap(arr,j, max_i));
                        Thread.Sleep(pause);
                    }
                }
            });
            return 0;
        }
    }
}
