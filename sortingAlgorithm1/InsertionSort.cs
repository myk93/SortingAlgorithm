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
        public InsertionSort(int size) : base(size)
        { }
        public InsertionSort(Collection<int> size) : base(size)
        { }

        public override int DoSort(Dispatcher d = null)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (arr[i] < arr[j])
                        {
                            d.Invoke(() => Swap(i, j));
                            Thread.Sleep(1);
                        }
                    }
                }
            }
            );
            return 0;
        }
    }
}
