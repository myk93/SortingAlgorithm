using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingAlgorithm
{
    internal struct subArray
    {
        internal int indexStart;
        internal int indexEnd;
        internal subArray(int a, int b)
        {
            indexStart = a;
            indexEnd = b;
        }
        internal int distance()
        {
            return indexEnd - indexStart;
        }
    }
}
