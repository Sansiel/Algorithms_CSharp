﻿using System;
using System.Collections.Generic;
using System.Collections;

namespace Graphs
{
    public class DoubleLinkedList
    {
        public static void MainG()
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            // добавление элементов
            linkedList.Add("Bob");
            linkedList.AddFirst("Bill");
            linkedList.Add("Tom");
            linkedList.AddMiddle("Kate");
            linkedList.AddMiddle("Sansiel");
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
    }

    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    public class DoublyLinkedList<T> : IEnumerable<T>  // двусвязный список
    {
        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public void AddMiddle(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> tempPrev = head;
            for (int i = 0; i < ((count-1)/2) ; i++)
            {
                tempPrev = tempPrev.Next;
            }
            DoublyNode<T> tempNext = tempPrev.Next; //можн беез этой переменной, но так нагляднее

            tempPrev.Next = node;
            node.Previous = tempPrev;
            node.Next = tempNext;
            tempNext.Previous = node;
            count++;

        }


        // удаление
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
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
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
