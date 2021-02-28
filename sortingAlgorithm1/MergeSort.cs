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
    public class MergeSort : BaseSort
    {
        public MergeSort() : base()
        { }
        public MergeSort(int size) : base(size)
        { }
        public MergeSort(Collection<int> arr) : base(arr)
        { }
        public override int DoSort(Dispatcher d = null)
        {
            DoSort(new subArray(0, arr.Count - 1), d);
            return 1;
        }
        private subArray DoSort(subArray current, Dispatcher d)
        {
            if (current.indexEnd - current.indexStart <= 1)
            {
                Swap(current.indexStart, current.indexEnd);
                return current;
            }
            subArray A = DoSort(new subArray(current.indexStart, current.indexEnd / 2), d);
            subArray B = DoSort(new subArray(current.indexEnd / 2 + 1, current.indexEnd), d);
            merge(A, B);
            return current;
        }
        private void merge(subArray a, subArray b)
        {
            int sizeA = a.distance();
            int sizeB = b.distance();
            Collection<int> temp = new Collection<int>();
            for (int i = 0, j = 0; i < sizeA || j < sizeB;)
            {

                if (i == sizeA)
                {
                    temp.Add(arr[b.indexStart + j]);
                    j++;
                }
                else if (j == sizeB)
                {
                    temp.Add(arr[a.indexStart + i]);
                    i++;
                }
                else
                {
                    if (arr[a.indexStart + i] > arr[b.indexStart + j])
                    {
                        temp.Add(arr[b.indexStart + j]);
                        j++;
                    }
                    else
                    {
                        temp.Add(arr[a.indexStart + i]);
                        i++;
                    }
                }
                for (int k  = 0; k < sizeA-1; k++)
                {
                    arr[a.indexStart + k] = temp[k];
                }
                for (int s = sizeA; s < sizeB + sizeA -2; s++)
                {
                    arr[b.indexStart + s - sizeA -1 ] = temp[s];
                }
            }
        }
    }
}
