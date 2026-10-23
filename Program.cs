using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixA = new LinkedList<LinkedList<int>>();
            matrixA.AddLast(new LinkedList<int>(new int[] { 1, 2, 3 }));
            matrixA.AddLast(new LinkedList<int>(new int[] { 4, 5, 6 }));

            var matrixB = new LinkedList<LinkedList<int>>();
            matrixB.AddLast(new LinkedList<int>(new int[] { 7, 8 }));
            matrixB.AddLast(new LinkedList<int>(new int[] { 9, 1 }));
            matrixB.AddLast(new LinkedList<int>(new int[] { 2, 3 }));

            Console.WriteLine("\nМатрица A:");
            PrintMatrix(matrixA);

            Console.WriteLine("\nМатрица B:");
            PrintMatrix(matrixB);

            var resultMatrix = MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("Результат умножения:");
            PrintMatrix(resultMatrix);
        }

        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var val in row)
                {
                    Console.Write("{0}\t", val);
                }
                Console.WriteLine();
            }
        }

        static int GetElement(LinkedList<LinkedList<int>> matrix, int rowIdx, int colIdx)
        {
            var rowNode = matrix.First;
            for (int i = 0; i < rowIdx; i++)
            {
                rowNode = rowNode.Next;
            }

            var colNode = rowNode.Value.First;
            for (int j = 0; j < colIdx; j++)
            {
                colNode = colNode.Next;
            }

            return colNode.Value;
        }

        static LinkedList<LinkedList<int>> MultiplyMatrices(LinkedList<LinkedList<int>> a, LinkedList<LinkedList<int>> b)
        {
            int rowsA = a.Count;
            int colsA = a.First.Value.Count;
            int colsB = b.First.Value.Count;

            var result = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < rowsA; i++)
            {
                var newRow = new LinkedList<int>();
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += GetElement(a, i, k) * GetElement(b, k, j);
                    }
                    newRow.AddLast(sum);
                }
                result.AddLast(newRow);
            }

            return result;
        }
    }
}
