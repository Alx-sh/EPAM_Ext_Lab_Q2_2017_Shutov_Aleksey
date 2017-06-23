/// <summary>
/// В кругу стоят N человек, пронумерованных от 1 до N. 
/// При ведении счета по кругу вычёркивается каждый второй человек, пока не останется один. 
/// Составить программу, моделирующую процесс.
/// </summary>
namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        /// <summary>
        /// Показывает содержимое списка.
        /// </summary>
        /// <param name="list">Входной список.</param>
        static void ShowList(List<int> list)
        {
            Console.WriteLine("\nСписок людей в кругу:");

            foreach (var st in list)
            {
                Console.WriteLine(st);
            }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int N;

            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Введите количество человек, или 0 для выхода:");

                    if (int.TryParse(Console.ReadLine(), out N) && N >= 0)
                    {
                        if (N == 0)
                        {
                            return;
                        }

                        break;
                    }

                    Console.WriteLine("Количество человек должно быть целочисленным и превышать 0!");
                }

                List<int> list = new List<int>(N);

                for (int i = 1; i <= N; i++)
                {
                    list.Add(i);
                }

                while (list.Count != 1)
                {
                    ShowList(list);

                    for (int i = 1; i < list.Count; i++)
                    {
                        list.RemoveAt(i);
                    }

                    Console.WriteLine("Нажмите любую клавишу для ведения счета по новому кругу.");
                    Console.ReadKey();
                }

                Console.Write("\nОстался один человек!");
                ShowList(list);
                Console.ReadKey();
            }
        }
    }
}
