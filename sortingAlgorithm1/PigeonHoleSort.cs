//using Sorting_algorithm;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Threading;

//namespace sortingAlgorithm1
//{
//    class PigeonHoleSort : BaseSort
//    {
//        public override int DoSort(Collection<int> arr, Dispatcher d = null, int pause = 0)
//        {
//            int min = arr[0];
//            int max = arr[0];
//            int range, i, j, index;

//            for (int a = 0; a < arr.Count; a++)
//            {
//                if (arr[a] > max)
//                    max = arr[a];
//                if (arr[a] < min)
//                    min = arr[a];
//            }

//            range = max - min + 1;
//            int[] phole = new int[range];

//            for (i = 0; i < arr.Count; i++)
//            {
//                phole[i] = 0;
               
//            }

//            for (i = 0; i < arr.Count; i++)
//            {
//                phole[arr[i] - min]++;

//            }

//            index = 0;

//            for (j = 0; j < range; j++)
//                while (phole[j]-- > 0)
//                    arr[index++] = j + min;

//        }

//    }
//}
