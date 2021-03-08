using Sorting_algorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace sortingAlgorithm1
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

            quickSortAlgo(d,arr[0],arr[arr.Count-1]);
            
            return 1;
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
