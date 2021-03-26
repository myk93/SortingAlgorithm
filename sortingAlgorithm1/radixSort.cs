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
    public class RadixSort :BaseSort
    {
        public RadixSort() : base()
        { }

        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
        {
            //pause *= 2;
            Task.Factory.StartNew(() =>
            {
                int max = this.Maximum(arr);
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
