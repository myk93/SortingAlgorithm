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
    public class DoubleSidedSelectionSort : BaseSort
    {
        public DoubleSidedSelectionSort() : base()
        { }
        public DoubleSidedSelectionSort(int size) : base(size)
        { }
        public DoubleSidedSelectionSort(Collection<int> size) : base(size)
        { }
        public override int DoSort(Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0, j = arr.Count - 1; i < j; i++, j--)
                {
                    int min = arr[i], max = arr[i];
                    int min_i = i, max_i = i;
                    for (int k = i; k <= j; k++)
                    {
                        if (arr[k] > max)
                        {
                            max = arr[k];
                            max_i = k;
                        }

                        else if (arr[k] < min)
                        {
                            min = arr[k];
                            min_i = k;
                        }
                    }

                    // shifting the min. 
                    d.Invoke(() => Swap(i, min_i));
                    Thread.Sleep(pause);
                    // Shifting the max. The equal condition 
                    // happens if we shifted the max to arr[min_i]  
                    // in the previous swap. 
                    if (arr[min_i] == max)
                    {
                        d.Invoke(() => Swap(j, min_i));
                        Thread.Sleep(pause);

                    }
                    else
                    {
                        d.Invoke(() => Swap(j, max_i));
                        Thread.Sleep(pause);
                    }
                }
                //int smallIndex;
                //int highestIndex;
                //int left = 0 ;
                //int right = arr.Count - 1;

                //while (left < right)
                //{
                //    smallIndex = left;
                //    highestIndex = (arr.Count - 1) - left;
                //    for (int j = left; j < (arr.Count - 1) - left; j++)
                //    {
                //        if (arr[j] < arr[smallIndex])
                //        {
                //            smallIndex = j;
                //        }
                //        if (smallIndex!=left)
                //        {

                //        }
                //        if (arr[j] > arr[highestIndex])
                //        {
                //            highestIndex = j;
                //        }

                //    }
                //    d.Invoke(() =>
                //    {

                //        Swap(left, smallIndex);

                //        Swap(arr.Count - left - 1, highestIndex);

                //    });
                //    left++;
                //    right--;

                //    Thread.Sleep(pause);

                //    }
            }
            );

            return 0;
        }
    }
}
