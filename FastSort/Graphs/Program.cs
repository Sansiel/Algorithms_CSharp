using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            string choose = "";
            while (choose != "stop")
            {
                Console.WriteLine("Choose - DoubleLinkedList (d) / CircleLinkedList (c) / MatrixGraph (m) / ListGraph(l) / BinaryTree (b) / HashTable (h)");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "d":
                        DoubleLinkedList.MainG();
                        break;
                    case "c":
                        CircleList.MainG();
                        break;
                    case "m":
                        AdjacencyMatrixGraph.MainG();
                        break;
                    case "l":
                        AdjacencyListGraph.MainG();
                        break;
                    case "b":
                        BinaryTree.MainG();
                        break;
                    case "h":
                        HashTableExample.MainG();
                        break;
                }
                Console.WriteLine("To end program type 'stop'");
            }
        }
    }
}
