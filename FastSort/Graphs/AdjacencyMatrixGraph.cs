using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class AdjacencyMatrixGraph
    {
        public static void MainG()
        {
            int[,] mas = { { 0, 1, 1, 0, 0, 0, 1 }, // матрица смежности
            { 1, 0, 1, 1, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 1, 0 } };

            int[] temp = new int[mas.GetLength(0)];
            for (int i = 1; i < mas.GetLength(1) + 1; i++)
            {
                temp[i - 1] = 0;
            }
            temp[0] = 1;

            Console.Write("FindDepth - ");
            FindDepth(1, mas, temp);
            Console.WriteLine();



            for (int i = 1; i < mas.GetLength(1) + 1; i++)
            {
                temp[i - 1] = 0;
            }



            Console.Write("FindDepth v2 - ");
            FindDepthv2(1, mas, temp);
            Console.WriteLine();

            
            Console.Write("FindWidth - ");
            FindWidth(mas);
            Console.WriteLine();

            return;
        }

        public static void FindDepth(int start, int[,] mas, int[] alreadyUsed)
        {
            Console.Write(start.ToString());
            for (int i = 1; i < mas.GetLength(1) + 1; i++)
            {
                if ((mas[start - 1, i - 1] == 1))
                {
                    if (alreadyUsed[i - 1] != 1)
                    {
                        alreadyUsed[i - 1] = 1;
                        FindDepth(i, mas, alreadyUsed);
                    }
                }
            }
            return;
        }

        public static void FindDepthv2(int start, int[,] mas, int[] alreadyUsed)
        {
            alreadyUsed[start - 1] = 1;
            Console.Write(start.ToString());
            for (int i = 1; i < mas.GetLength(1) + 1; i++)
            {
                if ((mas[start - 1, i - 1] == 1))
                {
                    if (alreadyUsed[i - 1] != 1)
                    {
                        FindDepthv2(i, mas, alreadyUsed);
                    }
                }
            }
            return;
        }

        public static void FindWidth(int[,] mas)
        {
            List<int> quaue = new List<int>();
            quaue.Add(1);
            int i = 0;
            while (quaue.Count!=mas.GetLength(0))
            {
                for (int j = 1; j < mas.GetLength(1) + 1; j++)
                {
                    if (mas[quaue[i]-1, j - 1] == 1)
                    {
                        if (quaue.Contains(j)) { }
                        else quaue.Add(j);
                    }
                }

                if (i < quaue.Count) i++;
            }

            foreach (int q in quaue) { Console.Write(q.ToString()); }
        }
    }
}
        /*public class Node
        {
            public int Data { get; set; }
        }
        public class Edge
        {
            public Node node { get; set; }
            public Node nodeNext { get; set; }
        }

        public class Graph
        {
            public Edge root = new Edge();  //не придумал как начать связь
            public int countNodes = 0;

            public void Create(int[,] mas)
            {
                for (int j = 1; j < mas.GetLength(0) + 1; j++)
                {
                    Node node = new Node();
                    node.Data = j;
                    node = FindDepth(node, root);
                    Edge edge = new Edge();
                    edge.node = node;
                    if (root is null) root = edge;

                    for (int i = 1; i < mas.GetLength(0) + 1; i++)
                    {
                        if (i == 1)
                        {
                            edge.nodeNext = new Node();
                            edge.nodeNext.Data = root.node.Data;
                        }
                    }
                    countNodes++;
                }
                return;
            }

            public Node FindDepth(Node node, Edge rootEdge)
            {
                FindDepth(rootEdge.nodeNext,) 
            }

            public
        }*/
