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
    public class MergeSort : BaseSort
    {
        public MergeSort() : base()
        { }


        public override int DoSort(Collection<int> arr, Dispatcher d = null, int wait = 0)
        {
            Task.Factory.StartNew(() =>
            {
                Collection<int> A = MergSort(arr,arr, d,0,arr.Count/2,arr.Count/2+1,arr.Count);
                for (int i = 0; i < A.Count; i++)
                {
                    
                    d.Invoke(() => arr[i] = A[i]);
                    Thread.Sleep(wait);

                }
            });
            return 1;
        }
        /*
        private subArray DoSort(subArray current, Dispatcher d)
        {
            if (current.indexEnd - current.indexStart <= 1)
            {
                return current;
            }
            subArray A = DoSort(new subArray(current.indexStart, current.indexEnd / 2), d);
            subArray B = DoSort(new subArray(current.indexEnd / 2 + 1, current.indexEnd), d);
            merge(A, B);
            return current;
        }
        */
        private Collection<int> MergSort(Collection<int> arr, Collection<int> arrToSort, Dispatcher d , int a1 ,int a2, int b1, int b2)
        {
            if (arrToSort.Count <= 1)
            {
                return arrToSort;
            }

            Collection<int> A = new Collection<int>();
            Collection<int> B = new Collection<int>();
          //  a1 = a1;// start of array A1
            int a3 = (a1 + a2) / 2 ;// end of array A1
            int a4 = (a1 + a2) / 2 +1 ;// start of array A2
            // a2 = a2 // end of array A2 
            //b1 = b1  //start of array B1
            //b2 = b2 //end of array B2
            int b3 = (b1 + b2) / 2; // end of array B1
            int b4 = (b1 + b2) / 2;// start of array B2

            for (int i = 0; i < arrToSort.Count; i++)
            {
                if (i < arrToSort.Count / 2)
                {
                    A.Add(arrToSort[i]);
                }
                else
                {
                    B.Add(arrToSort[i]);
                }
            }
            //for (int k = a1; k < a2; k++)
            //{
            //    d.Invoke(() => arr[k] = A[k - a1]);
            //    Thread.Sleep(5);
            //}
            //for (int j = b1; j < b2; j++)
            //{
            //    d.Invoke(() => arr[j] = A[j - b1]);
            //    Thread.Sleep(5);

            //}
            A = MergSort(arr,A, d,a1,a3,a4,a2);
            B = MergSort(arr,B, d, b1, b3, b4, b2);
            for (int k = a1; k < a2; k++)
            {
                d.Invoke(() => arr[k] = A[k - a1]);
                Thread.Sleep(1);
            }
            if (b2 / 2 == 0)
            {
                for (int j = b1; j < b2 + 1; j++)
                {
                    d.Invoke(() => arr[j] = A[j - b1]);
                    Thread.Sleep(1);
                }
            }
            else
            {
                for (int j = b1; j < b2 - 1; j++)
                {
                    d.Invoke(() => arr[j] = A[j - b1]);
                    Thread.Sleep(1);
                }
            }
            arrToSort = Merge(A, B);
           
            return arrToSort;
        }

        private Collection<int> Merge(Collection<int> A, Collection<int> B)
        {
            Collection<int> toReturn = new Collection<int>();
            for (int i = 0, j = 0; i < A.Count || j < B.Count;)
            {
                if (i == A.Count)
                {
                    toReturn.Add(B[j]);
                    j++;
                }
                else if (j == B.Count)
                {
                    toReturn.Add(A[i]);
                    i++;
                }
                else if (A[i] > B[j])
                {
                    toReturn.Add(B[j]);
                    j++;
                }
                else
                {
                    toReturn.Add(A[i]);
                    i++;
                }
            }
            return toReturn;
        }
    }
}
