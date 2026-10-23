using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] months = {
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };

            Dictionary<string, int[]> temperatures = new Dictionary<string, int[]>();
            Random ran = new Random();

            foreach (var month in months)
            {
                int[] days = new int[30];
                for (int i = 0; i < 30; i++)
                {
                    days[i] = ran.Next(-25, 35);
                }
                temperatures.Add(month, days);
            }

            double[] averages = CalculateAverages(temperatures);

            Array.Sort(averages);

            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (double t in averages)
            {
                Console.Write($"{t:F1} °C; ");
            }
            Console.WriteLine();
        }

        static double[] CalculateAverages(Dictionary<string, int[]> dict)
        {
            double[] averages = new double[dict.Count];
            int index = 0;

            foreach (var pair in dict)
            {
                int sum = 0;
                for (int i = 0; i < pair.Value.Length; i++)
                {
                    sum += pair.Value[i];
                }

                double avg = (double)sum / pair.Value.Length;
                averages[index++] = avg;
                Console.WriteLine($"{pair.Key}: {avg:F1} °C");
            }

            return averages;
        }
    }
}
