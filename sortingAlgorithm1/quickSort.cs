using Sorting_algorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

            Quick_Sort(0,arr.Count-1);
            
            return 1;
        }
        private  void Quick_Sort(int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition( left, right);

                if (pivot > 1)
                {
                    Quick_Sort( left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort( pivot + 1, right);
                }
            }

        }

        private  int Partition( int left, int right)
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

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }
        private void quickSortAlgo( Dispatcher d, int left, int right)
        {
            Task.Factory.StartNew(() => {
                if (IsSorted())
                {
                    return;
                }
                int pivot = arr[0];
                int leftSide = arr[left];
                int rightSide = arr[right];


                quickSortAlgo(d,left+1,left - 1);
               
            });

            throw new NotImplementedException();
        }
    }
}
