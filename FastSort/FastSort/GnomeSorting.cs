using System;
using System.Collections.Generic;
using System.Text;

namespace Sorts
{
    class GnomeSorting
    {
        public static void MainSort()
        {
            int[] array = { 5, 3, 6, 4, 2, 9, 1, 8, 7 }; //Массив
            //int[] array = { 10, 10, 6, 10, 6, 2 };
            GnomeSort(array);
            string str = "";
            foreach (int a in array) { str += a.ToString() + ", "; }
            Console.WriteLine("Sorted: " + str);
            return;
        }

        static void GnomeSort(int[] inArray)
        {
            int i = 1;
            int j = 2;
            while (i < inArray.Length)
            {
                if (inArray[i - 1] < inArray[i])
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    Swap(inArray, i - 1, i);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j += 1;
                    }
                }
            }
        }

        //перестановка местами двух элементов в массиве
        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
