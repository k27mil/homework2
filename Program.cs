using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> images = new List<int>(64);
            for (int i = 1; i <= 32; i++)
            {
                images.Add(i);
                images.Add(i);
            }

            Console.WriteLine("Изначальный List:");
            Console.WriteLine(string.Join(" ", images));

            Random rnd = new Random();
            List<int> shuffledImages = images.OrderBy(x => rnd.Next()).ToList();

            Console.WriteLine("Полученный List:");
            Console.WriteLine(string.Join(" ", shuffledImages));
        }
    }
}
