using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework2
{
    internal class Program
    {
        static string Glasnie = "аеёиоуыэюяaeiouyАЕЁИОУЫЭЮЯAEIOUY";
        static string Soglasnie = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxzБВГДЖЗЙКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXZ";

        static void count(List<char> chars, out int glasnie, out int soglasnie)
        {
            glasnie = 0;
            soglasnie = 0;
            foreach (char c in chars)
            {
                if (Glasnie.Contains(c))
                {
                    glasnie++;
                }
                if (Soglasnie.Contains(c))
                {
                    soglasnie++;
                }
            }
        }

        static void Main(string[] args)
        {
            string file = @"C:\Users\user\Desktop\проверка.txt";
            List<char> characers = new List<char>(File.ReadAllText(file));

            count(characers, out int s, out int g);
            Console.WriteLine($"Гласных: {s}");
            Console.WriteLine($"Согласных: {g}");
        }
    }
}
