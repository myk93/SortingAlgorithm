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
    public class SelectionSort : BaseSort
    {
        public SelectionSort() : base()
        { }

        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
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

                    d.Invoke(() =>
                    {
                        Swap(arr,i,smallIndex);
                        //int temp = arr[smallIndex];
                        //arr[smallIndex] = arr[i];
                        //arr[i] = temp;
                    });
                    Thread.Sleep(pause);

                }
            }
            );
            return 0;
        }
    }
}
