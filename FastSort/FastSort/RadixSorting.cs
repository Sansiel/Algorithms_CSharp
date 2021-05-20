using System;
using System.Collections;

namespace Sorts
{
    class RadixSorting
    {
        public static void MainSort()
        {
            int[] array = { 5, 3, 6, 4, 2, 9, 1, 8, 7 }; //Массив
            //int[] array = { 10, 10, 6, 10, 6, 2 };
            sorting(array);
            string str = "";
            foreach (int a in array) { str += a.ToString() + ", "; }
            Console.WriteLine("Sorted: " + str);
            return;
        }

        public static void sorting(int[] array)
        {
            sorting(array, 10, 2);
        }

        public static void sorting(int[] arr, int range, int length)
        {
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; i++)
                lists[i] = new ArrayList();

            for (int step = 0; step < length; step++)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; i++)
                {
                    int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /
                                                  (int)Math.Pow(range, step);
                    lists[temp].Add(arr[i]);
                }
                //сборка
                int k = 0;
                for (int i = 0; i < range; i++)
                {
                    for (int j = 0; j < lists[i].Count; j++)
                    {
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; i++)
                    lists[i].Clear();
            }
        }

    }
}
