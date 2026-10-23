using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    internal class Program
    {
        class Babushka
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Diseases { get; set; } = new List<string>();
            public List<string> Medicines { get; set; } = new List<string>();
        }

        class Hospital
        {
            public string Name { get; set; }
            public List<string> TreatedDiseases { get; set; } = new List<string>();
            public int Capacity { get; set; }
            public List<Babushka> Patients { get; set; } = new List<Babushka>();

            public double GetFillPercentage()
            {
                return Capacity == 0 ? 0 : (double)Patients.Count / Capacity * 100;
            }
        }

        static void Main()
        {
            Stack<Hospital> hospitals = new Stack<Hospital>();
            hospitals.Push(new Hospital { Name = "Клиника 1", Capacity = 2, TreatedDiseases = new List<string> { "Грипп", "Кашель" } });
            hospitals.Push(new Hospital { Name = "Клиника 2", Capacity = 3, TreatedDiseases = new List<string> { "Давление", "Артрит" } });

            Queue<Babushka> babushkas = new Queue<Babushka>();

            while (true)
            {
                Console.WriteLine("Введите имя бабули (пустая строка для завершения):");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) break;

                Console.WriteLine("Введите возраст:");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите болезни через запятую (если нет, нажмите Enter):");
                string diseasesInput = Console.ReadLine();
                List<string> diseases = string.IsNullOrWhiteSpace(diseasesInput)
                    ? new List<string>()
                    : diseasesInput.Split(',').Select(d => d.Trim()).ToList();

                babushkas.Enqueue(new Babushka { Name = name, Age = age, Diseases = diseases });
            }

            while (babushkas.Count > 0)
            {
                var babushka = babushkas.Dequeue();
                bool placed = false;
                List<Hospital> tempHospitals = new List<Hospital>();

                while (hospitals.Count > 0)
                {
                    var hospital = hospitals.Pop();
                    tempHospitals.Add(hospital);

                    if (hospital.Patients.Count >= hospital.Capacity)
                        continue;

                    if (babushka.Diseases.Count == 0)
                    {
                        hospital.Patients.Add(babushka);
                        placed = true;
                        break;
                    }

                    int matches = babushka.Diseases.Count(d => hospital.TreatedDiseases.Contains(d));
                    if (matches > babushka.Diseases.Count / 2.0)
                    {
                        hospital.Patients.Add(babushka);
                        placed = true;
                        break;
                    }
                }

                tempHospitals.Reverse();
                foreach (var h in tempHospitals)
                {
                    hospitals.Push(h);
                }

                if (!placed)
                {
                    Console.WriteLine($"Бабуля {babushka.Name} осталась на улице плакать.");
                }
            }

            Console.WriteLine("\n--- Статистика по больницам ---");
            foreach (var hospital in hospitals)
            {
                Console.WriteLine($"Больница: {hospital.Name}");
                Console.WriteLine($"Лечат: {string.Join(", ", hospital.TreatedDiseases)}");
                Console.WriteLine($"Пациенты: {string.Join(", ", hospital.Patients.Select(p => p.Name))}");
                Console.WriteLine($"Заполненность: {hospital.Patients.Count}/{hospital.Capacity} ({hospital.GetFillPercentage():F1}%)");
                Console.WriteLine();
            }
        }
    }
}
