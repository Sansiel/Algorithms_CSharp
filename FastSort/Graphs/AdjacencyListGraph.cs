using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class AdjacencyListGraph
    {
        public static void MainG()
        {
            int[][] W = new int[5][];
            W[0] = new int[3] { 2, 3, 4};
            W[1] = new int[3] { 1, 4, 5};
            W[2] = new int[2] { 1, 4};
            W[3] = new int[4] { 1, 2, 3, 5};
            W[4] = new int[2] { 2, 4};

            int[,] array = new int[5, 5];
            for (int i = 0; i < W.Length; i++)
            {
                for (int j=0; j < W.Length; j++)
                {
                    array[i, j] = 0;
                }
                foreach (int j in W[i])
                {
                    array[i, j-1] = 1;
                }
            }

            for (int i = 0; i < W.Length; i++)
            {
                for (int j = 0; j < W.Length; j++)
                {
                    Console.Write(array[i, j].ToString() + ", ");
                }
                Console.WriteLine();
            }
            return;
        }
    }
}
