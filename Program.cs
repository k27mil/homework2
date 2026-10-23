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
            int[,] temperature = new int[12, 30];
            Random ran = new Random();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = ran.Next(-25, 35);
                }
            }

            double[] avgTemps = CalculateMonthlyAverages(temperature);

            for (int i = 0; i < avgTemps.Length; i++)
            {
                Console.WriteLine($"Месяц {i + 1}: {avgTemps[i]:F1} °C");
            }

            Array.Sort(avgTemps);

            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (double t in avgTemps)
            {
                Console.Write($"{t:F1} °C; ");
            }
            Console.WriteLine();
        }
        static double[] CalculateMonthlyAverages(int[,] temp)
        {
            double[] averages = new double[12];

            for (int i = 0; i < 12; i++)
            {
                int sum = 0;
                for (int j = 0; j < 30; j++)
                {
                    sum += temp[i, j];
                }
                averages[i] = (double)sum / 30.0;
            }

            return averages;
        }
    }
}
