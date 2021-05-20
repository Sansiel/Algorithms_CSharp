using System;
using System.Linq;

namespace Sorts
{
    class CountSorting
    {
        //Крайне плохо работает на массивах, где значения с огромной разницей между друг другом
        //Не работает, если числа есть одинаковые

        public static void MainSort()
        {
            int[] array = { 5, 3, 6, 4, 2, 9, 1, 8, 7 }; //Массив
            //int[] array = { 10, 10, 6, 10, 6, 2 };
            CountingSort(array);
            string str = "";
            foreach (int a in array) { str += a.ToString() + ", "; }
            Console.WriteLine("Sorted: " + str);
            return;
        }


        private static void CountingSort(int[] arr)
        {

            int max = arr.Max();
            int min = arr.Min();

            int[] count = new int[max - min + 1];
            for (int i = 0; i < count.Length; i++) { count[i] = 0; }
            int z = 0;

            
            for (int i = 0; i < arr.Length; i++) //подсчёт
            {
                count[arr[i] - min]++;
            }

            for (int i = min; i < max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    arr[z] = i;
                    z++;
                }
            }
            arr[arr.Length - 1] = max;
        }
    }
}
