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
    public class BucketSort : BaseSort
    {
        public BucketSort() : base()
        { }
        public BucketSort(int size) : base(size)
        { }
        public BucketSort(Collection<int> size) : base(size)
        { }

        public override int DoSort(Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                List<InsertionSort> temp = new List<InsertionSort>();
                int num = 8;
                for (int i = 1; i <= num + 1; i++)
                {
                    temp.Add(new InsertionSort());
                    for (int j = 0; j < arr.Count; j++)
                    {
                        if ((i - 1) * ((float)arr.Count / num) <= arr[j] && arr[j] < (i * ((float)arr.Count / num)))
                        {
                            temp[i - 1].arr.Add(arr[j]);
                        }
                    }
                }
                int k = 0;
                foreach (var item in temp)
                {
                    for (int s = 0; s < item.arr.Count; s++)
                    {
                        d.Invoke(() => arr[k] = item.arr[s]);
                        Thread.Sleep(pause);
                        k++;
                    }
                }
                for (int i = 0; i < num; i++)
                {
                    d.Invoke(() => temp[i].DoSort(d));
                }
                Thread.Sleep(500);
                k = 0;
                foreach (var item in temp)
                {
                    for (int s = 0; s < item.arr.Count; s++)
                    {
                        Thread.Sleep(pause);
                        d.Invoke(() => arr[k] = item.arr[s]);
                        k++;
                    }
                }
            });

            return 0;
        }
    }
}
