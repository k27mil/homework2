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
        class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int YearOfBirth { get; set; }
            public string Exam { get; set; }
            public int Points { get; set; }
        }
        static void Main()
        {
            List<Student> students = new List<Student>();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "students.txt");

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                if (parts.Length == 5)
                {
                    students.Add(new Student
                    {
                        LastName = parts[0],
                        FirstName = parts[1],
                        YearOfBirth = int.Parse(parts[2]),
                        Exam = parts[3],
                        Points = int.Parse(parts[4])
                    });
                }
            }

            while (true)
            {
                Console.WriteLine("Введите команду (Новый студент / Удалить / Сортировать / Выход):");
                string command = Console.ReadLine();

                if (command == "Новый студент")
                {
                    Console.Write("Фамилия: ");
                    string lName = Console.ReadLine();
                    Console.Write("Имя: ");
                    string fName = Console.ReadLine();
                    Console.Write("Год рождения: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Экзамен: ");
                    string exam = Console.ReadLine();
                    Console.Write("Баллы: ");
                    int points = int.Parse(Console.ReadLine());

                    students.Add(new Student { LastName = lName, FirstName = fName, YearOfBirth = year, Exam = exam, Points = points });
                }
                else if (command == "Удалить")
                {
                    Console.Write("Фамилия: ");
                    string lName = Console.ReadLine();
                    Console.Write("Имя: ");
                    string fName = Console.ReadLine();

                    students.RemoveAll(s => s.LastName == lName && s.FirstName == fName);
                }
                else if (command == "Сортировать")
                {
                    students = students.OrderBy(s => s.Points).ToList();
                    foreach (var s in students)
                    {
                        Console.WriteLine($"{s.LastName} {s.FirstName} - {s.Points}");
                    }
                }
                else if (command == "Выход")
                {
                    break;
                }
            }
        }
    }
}
