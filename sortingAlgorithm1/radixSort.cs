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
    public class RadixSort :BaseSort
    {
        public RadixSort() : base()
        { }
        public RadixSort(int size) : base(size)
        { }
        public RadixSort(Collection<int> arr) : base(arr)
        { }

        public override int DoSort(Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
            {
                int max = this.Maximum();
                max = (int)Math.Log10(max);
                List<List<int>> cups = new List<List<int>>();
                for (int i = 0; i < 10; i++)
                {
                    cups.Add(new List<int>());
                }
                int temp;
                int count = 1;
                for (int i = 0; i < max + 1; i++, count *= 10)
                {
                    for (int j = 0; j < arr.Count; j++)
                        cups[((arr[j] / count) % 10)].Add(arr[j]);
                    temp = 0;
                    for (int k = 0; k < 10; k++)
                    {
                        for (int t = 0; t < cups[k].Count; t++, temp++)
                        {
                            d.Invoke(() => arr[temp] = cups[k][t]);
                            Thread.Sleep(pause);
                        }
                        cups[k].Clear();
                    }
                }
            });
            return 0;
        }
    }
}
