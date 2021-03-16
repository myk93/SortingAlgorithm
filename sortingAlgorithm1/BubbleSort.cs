using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
//using System.Windows.Threading;

namespace Sorting_algorithm
{
    public class BubbleSort :BaseSort
    {
        public BubbleSort() : base()
        {}
        public BubbleSort(int size) : base(size)
        { }
        public BubbleSort(Collection<int> size) : base(size)
        { }
        public override int DoSort(Collection<int> arr,Dispatcher d = null, int pause = 0)
        {
            Task.Factory.StartNew(() =>
                {
                    bool IsSorted;
                    for (int i = arr.Count - 1; (i >= 1); i--)
                    {
                        IsSorted = true;
                        numOfTries++;
                        for (int j = 0; j < i ; j++)
                        {
                            if (arr[j] > arr[j + 1])
                            {
                                if (d != null)
                                {
                                    d.Invoke( () =>Swap(arr,j, j + 1));
                                    Thread.Sleep(pause/2);
                                }
                                else
                                    Swap(arr,j, j + 1);
                                
                                numOfSwap++;
                                IsSorted = false;
                            }
                        }
                        if (IsSorted)
                        {
                            break;
                        }
                    }
                }
            );
            return numOfSwap;
        }
    }
}
