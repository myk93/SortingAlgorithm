using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sorting_algorithm
{
    public class InsertionSort : BaseSort
    {
        public InsertionSort() : base()
        { }

        public override int DoSort(Collection<int> arr,Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (arr[i] < arr[j])
                        {
                            d.Invoke(() => Swap(arr,i, j));
                            Thread.Sleep(pause);
                        }
                    }
                }
            }
            );
            return 0;
        }
    }
}
