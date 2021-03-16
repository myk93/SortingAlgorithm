using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sorting_algorithm
{
    public class BogoSort : BaseSort
    {
        public BogoSort() : base()
        { }

        public override int DoSort(Collection<int> arr, Dispatcher d, int pause)
        {
            Task.Factory.StartNew(() =>
            {
                while (!IsSorted(arr))
                {

                    numOfTries++;
                    d.Invoke(() => Shuffle(arr));
                    Thread.Sleep(pause);
                    // Print();

                }
            });
            return numOfSwap;

        }

    }
}
