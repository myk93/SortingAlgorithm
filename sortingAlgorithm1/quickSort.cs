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
    class quickSort : BaseSort
    {
        public quickSort() : base()
        { }
        public quickSort(int size) : base(size)
        { }
        public quickSort(Collection<int> size) : base(size)
        { }
        public override int DoSort(Dispatcher d = null, int pause = 0)
        {

            Quick_Sort(0, arr.Count - 1, d,pause);

            return 1;
        }
        private void Quick_Sort(int left, int right, Dispatcher d,int pause)
        {
            Task.Factory.StartNew(() =>
            {
                if (left < right)
                {
                    int pivot = Partition(left, right, d,pause);

                    if (pivot > 1)
                    {
                        Quick_Sort(left, pivot - 1, d,pause);
                    }
                    if (pivot + 1 < right)
                    {
                        Quick_Sort(pivot + 1, right, d,pause);
                    }
                }
            });

        }

        private int Partition(int left, int right, Dispatcher d,int pause)
        {

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
                    d.Invoke(() => Swap(left, right));
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
