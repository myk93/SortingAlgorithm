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
    public class SelectionSort : BaseSort
    {
        public SelectionSort() : base()
        { }
        public SelectionSort(int size) : base(size)
        { }
        public SelectionSort(Collection<int> size) : base(size)
        { }
        public override int DoSort(Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                int smallIndex = 0;
                for (int i = 0; i < arr.Count; i++)
                {
                    smallIndex = i;
                    for (int j = i; j < arr.Count; j++)
                    {
                        if (arr[j] < arr[smallIndex])
                        {
                            smallIndex = j;
                        }
                    }
                  
                    d.Invoke(() => Swap(i, smallIndex));
                    Thread.Sleep(pause);

                }
            }
            );
            return 0;
        }
    }
}
