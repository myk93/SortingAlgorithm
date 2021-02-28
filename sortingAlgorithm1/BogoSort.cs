using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace Sorting_algorithm
{
    public class BogoSort :BaseSort
    {
        public BogoSort() : base()
        { }
        public BogoSort(int size) : base(size)
        { }
        public BogoSort(Collection<int> arr) : base(arr)
        { }
        public override void DoSort(Dispatcher d)
        {

           while (!IsSorted())
            {
               // Print();
                numOfTries++;
                d.Invoke(() => Shuffle());
                Thread.Sleep(3000);
            }
        }

    }
}
