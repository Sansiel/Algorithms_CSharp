using System;

namespace Sorts
{
    public class FastSorting
    {
        static int counter = 0;

        public static void MainSort()
        {
            int[] array = { 5, 3, 6, 4, 2, 9, 1, 8, 7 }; //Массив
            QuickSort(array);
            string str = "";
            foreach (int a in array) { str += a.ToString(); }
            Console.WriteLine("Sorted: " + str);
            return;
        }


        static void QuickSort(int[] a) //Функция для создания start и end эллемента
        {
            QuickSort(a, 0, a.Length - 1);
        }


        static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end); //Вызов функции определения маркера
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }


        static int partition(int[] array, int start, int end)  //Функция определения маркера
        {
            /* //test material */
            counter++;
            string str = " ";
            foreach (int a in array) { str += a.ToString(); }
            Console.WriteLine("Iter #" + counter.ToString() + str + " Start - " + start.ToString() + " End - " + end.ToString());


            int temp;
            int marker = start;  //Ищем где менять
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
    }
}
