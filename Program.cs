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
            int[,] matrixA = {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            int[,] matrixB = {
                { 7, 8 },
                { 9, 1 },
                { 2, 3 }
            };

            Console.WriteLine("Матрица A:");
            PrintMatrix(matrixA);

            Console.WriteLine("\nМатрица B:");
            PrintMatrix(matrixB);

            int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("\nРезультат умножения:");
            PrintMatrix(resultMatrix);
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static int[,] MultiplyMatrices(int[,] a, int[,] b)
        {
            int rowsA = a.GetLength(0);
            int colsA = a.GetLength(1);
            int rowsB = b.GetLength(0);
            int colsB = b.GetLength(1);

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
    }
}
