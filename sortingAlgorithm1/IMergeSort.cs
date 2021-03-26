//using Sorting_algorithm;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Threading;

//namespace sortingAlgorithm1
//{
//    class IMergeSort : BaseSort
//    {
//        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
//        {

//            int curr_size;


//            int left_start;


//            // Merge subarrays in bottom up 
//            // manner. First merge subarrays 
//            // of size 1 to create sorted 
//            // subarrays of size 2, then merge
//            // subarrays of size 2 to create 
//            // sorted subarrays of size 4, and
//            // so on.
//            for (curr_size = 1; curr_size <= arr.Count - 1;curr_size = 2 * curr_size)
//            {

//                // Pick starting point of different
//                // subarrays of current size
//                for (left_start = 0; left_start < arr.Count - 1; left_start += 2 * curr_size)
//                {
//                    // Find ending point of left 
//                    // subarray. mid+1 is starting 
//                    // point of right
//                    int mid = left_start + curr_size - 1;

//                    int right_end = Math.Min(left_start + 2 * curr_size - 1, arr.Count - 1);

//                    // Merge Subarrays arr[left_start...mid]
//                    // & arr[mid+1...right_end]
//                    Merge(arr, left_start, mid, right_end,d,pause);
//                }
//            }
//            return 0;
//        }

//        static void Merge(Collection<int> arr, int l, int m, int r,Dispatcher d,int pause)
//        {
//            Task.Factory.StartNew(() =>
//            {
//                int i, j, k;
//                int n1 = m - l + 1;
//                int n2 = r - m;

//                int[] L = new int[n1];
//                int[] R = new int[n2];


//                for (i = 0; i < n1; i++)
//                    L[i] = arr[l + i];
//                for (j = 0; j < n2; j++)
//                    R[j] = arr[m + 1 + j];


//                i = 0;
//                j = 0;
//                k = l;
//                while (i < n1 && j < n2)
//                {
//                    if (L[i] <= R[j])
//                    {
//                        d.Invoke(() => arr[k] = L[i]);
//                        i++;
//                    }
//                    else
//                    {
//                        d.Invoke(() => arr[k] = R[i]);
//                        j++;
//                    }
//                    k++;
//                }


//                while (i < n1)
//                {
//                    d.Invoke(() => arr[k] = L[i]);
//                    i++;
//                    k++;
//                }

//                /* Copy the remaining elements of
//                R[], if there are any */
//                while (j < n2)
//                {
//                    d.Invoke(() => arr[k] = R[j]);
//                    j++;
//                    k++;
//                }
//            });
            
//        }
//    }
//}
