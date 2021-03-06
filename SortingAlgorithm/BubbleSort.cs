﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

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
        public override void DoSort()
        {
            Task.Factory.StartNew(() =>
                {
                    bool IsSorted;
                    for (int i = arr.Count - 1; (i >= 1); i--)
                    {
                        IsSorted = true;
                        numOfTries++;
                        for (int j = 0; j < i - 1; j++)
                        {
                            if (arr[j] > arr[j + 1])
                            {
                                Print();
                                Application.Current.Dispatcher.Invoke()
                                Swap(j, j + 1);
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
           
        }
    }
}
