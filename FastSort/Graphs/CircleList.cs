using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class CircleList
    {
        public static void MainG()
        {
            CircleLinkedList<string> linkedList = new CircleLinkedList<string>();
            // добавление элементов
            linkedList.Add("Bob");
            linkedList.Add("Bill");
            linkedList.Add("Tom");
            linkedList.Add("Kate");
            linkedList.Add("Sansiel");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            // удаление
            linkedList.Remove("Bill");
            Console.WriteLine(" ");

            // перебор с последнего элемента
            foreach (var t in linkedList)
            {
                Console.WriteLine(t);
            }
            return;
        }


        public class CirleNode<T>
        {
            public CirleNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public CirleNode<T> Next { get; set; }
        }

        public class CircleLinkedList<T> : IEnumerable<T>  // двусвязный список
        {
            CirleNode<T> tail; // хвостовой/последний элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(T data)
            {
                CirleNode<T> node = new CirleNode<T>(data);

                if (tail == null)
                {
                    tail = node;
                    tail.Next = node;
                }
                else
                {
                    node.Next = tail.Next;
                    tail.Next = node;
                }
                tail = node;
                count++;
            }


            // удаление
            public bool Remove(T data)
            {
                CirleNode<T> current = tail.Next;

                // поиск удаляемого узла
                while (current != null)
                {
                    if (current.Next.Data.Equals(data))
                    {
                        break;
                    }
                    current = current.Next;
                }
                if ((current != null) && (current.Next != null))
                {
                    if (count == 1) tail = null;
                    else current.Next = current.Next.Next;
                    count--;
                    return true;
                }
                return false;
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }

            public void Clear()
            {
                tail = null;
                count = 0;
            }

            public bool Contains(T data)
            {
                CirleNode<T> current = tail;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }





            // От интерфейса
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                CirleNode<T> current = tail.Next;
                for (int i=0; i<count; i++)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
    }
}