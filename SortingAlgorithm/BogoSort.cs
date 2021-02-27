using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting_algorithm
{
    public class BogoSort :BaseSort
    {
        public BogoSort() : base()
        { }
        public BogoSort(int size) : base(size)
        { }

        public override void DoSort()
        {
            while (!IsSorted())
            {
                Print();
                numOfTries++;
                Shuffle();
            }
        }

    }
}
