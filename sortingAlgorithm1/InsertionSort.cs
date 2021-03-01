using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] < arr[j])
                        Swap(i, j);
                }
            }
            return 0;
        }
    }
}
