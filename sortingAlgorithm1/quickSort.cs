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
    class QuickSort : BaseSort
    {
        public QuickSort() : base()
        { }

        public override int DoSort(Collection<int> arr,Dispatcher d = null, int pause = 0)
        {

            Quick_Sort(arr,0, arr.Count - 1, d,pause);

            return 1;
        }
        private void Quick_Sort(Collection<int> arr,int left, int right, Dispatcher d,int pause)
        {
            Task.Factory.StartNew(() =>
            {
                if (left < right)
                {
                    int pivot = Partition(arr,left, right, d,pause);

                    if (pivot > 1)
                    {
                        Quick_Sort(arr,left, pivot - 1, d,pause);
                    }
                    if (pivot + 1 < right)
                    {
                        Quick_Sort(arr,pivot + 1, right, d,pause);
                    }
                }
            });

        }

        private int Partition(Collection<int> arr,int left, int right, Dispatcher d,int pause)
        {
            pause *= 2;
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;
                    d.Invoke(() => Swap(arr,left, right));
                    Thread.Sleep(pause);
                }
                else
                {
                    return right;
                }
            }
        }

    }
}
