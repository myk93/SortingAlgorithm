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
    public class BucketSort : BaseSort
    {
        public BucketSort() : base()
        { }

        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
        {
            InsertionSort iSort = new InsertionSort();
            Task.Factory.StartNew(() =>
            {
                List< Collection<int> > temp = new List<Collection<int>>();
                int num = 8;
                for (int i = 1; i <= num + 1; i++)
                {
                    temp.Add(new Collection<int>());
                    for (int j = 0; j < arr.Count; j++)
                    {
                        if ((i - 1) * ((float)arr.Count / num) <= arr[j] && arr[j] < (i * ((float)arr.Count / num)))
                        {
                            temp[i - 1].Add(arr[j]);
                        }
                    }
                }
                int k = 0;
                foreach (var item in temp)
                {
                    for (int s = 0; s < item.Count; s++)
                    {
                        d.Invoke(() => arr[k] = item[s]);
                        Thread.Sleep(pause);
                        k++;
                    }
                }
                for (int i = 0; i < num; i++)
                {
                    d.Invoke(() => iSort.DoSort( temp[i],d));
                }
                Thread.Sleep(500);
                k = 0;
                foreach (var item in temp)
                {
                    for (int s = 0; s < item.Count; s++)
                    {
                        Thread.Sleep(pause);
                        d.Invoke(() => arr[k] = item[s]);
                        k++;
                    }
                }
            });

            return 0;
        }
    }
}
