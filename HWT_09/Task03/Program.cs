/// <summary>
/// Написать методы поиска элемента в массиве (например, поиск всех положительных элементов в массиве) в виде:
/// 1. Метода, реализующего поиск напрямую;
/// 2. Метода, которому условие поиска передаётся через делегат;
/// 3. Метода, которому условие поиска передаётся через делегат в виде анонимного метода;
/// 4. Метода, которому условие поиска передаётся через делегат в виде лямбда-выражения;
/// 5. LINQ-выражения
/// Сравнить скорость выполнения вычислений.
/// </summary>
namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    class Program
    {
        public delegate bool Function(int x);

        public static bool IsPositive(int x)
        {
            return x > 0;
        }

        public static int[] GetPositive(int[] array)
        {
            var lst = new List<int>();

            foreach (var item in array)
            {
                if (item > 0)
                {
                    lst.Add(item);
                }
            }

            return lst.ToArray();
        }

        public static int[] GetPositive(int[] array, Predicate<int> condition)
        {
            var lst = new List<int>();

            foreach (var item in array)
            {
                if (condition(item))
                {
                    lst.Add(item);
                }
            }

            return lst.ToArray();
        }

        public static int[] GetPositiveLinq(int[] array)
        {
            var arr = from item in array
                      where item > 0
                      select item;
            return arr.ToArray();
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int[] mas = new int[300];
            Random rnd = new Random();
            Predicate<int> condition1 = delegate (int x) { return x > 0; };
            Predicate<int> condition2 = (x) => x > 0;
            List<long> ticks;

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(-100, 100);
            }

            Console.Write("Поиск напрямую: ");
            ticks = new List<long>();
            for (int i = 0; i < 30; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                var newMas = GetPositive(mas);
                sw.Stop();
                ticks.Add(sw.ElapsedTicks);
            }

            ticks.Sort();
            Console.WriteLine("\nТики:");
            foreach (var item in ticks)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nМедиана: {0}", ticks[ticks.Count / 2]);


            Console.Write("\nПоиск через делегат: ");
            ticks = new List<long>();
            for (int i = 0; i < 30; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                var newMas = GetPositive(mas, IsPositive);
                sw.Stop();

                ticks.Add(sw.ElapsedTicks);
            }

            ticks.Sort();
            Console.WriteLine("\nТики:");
            foreach (var item in ticks)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nМедиана: {0}", ticks[ticks.Count / 2]);


            Console.Write("\nПоиск через делегат в виде анонимного метода: ");
            ticks = new List<long>();
            for (int i = 0; i < 30; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                var newMas = GetPositive(mas, condition1);
                sw.Stop();
                ticks.Add(sw.ElapsedTicks);
            }

            ticks.Sort();
            Console.WriteLine("\nТики:");
            foreach (var item in ticks)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nМедиана: {0}", ticks[ticks.Count / 2]);


            Console.Write("\nПоиск через делегат в виде лямбда-выражения: ");
            ticks = new List<long>();
            for (int i = 0; i < 30; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                var newMas = GetPositive(mas, condition2);
                sw.Stop();
                ticks.Add(sw.ElapsedTicks);
            }

            ticks.Sort();
            Console.WriteLine("\nТики:");
            foreach (var item in ticks)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nМедиана: {0}", ticks[ticks.Count / 2]);


            Console.Write("\nПоиск c помощью LINQ-выражения: ");
            ticks = new List<long>();
            for (int i = 0; i < 30; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                var newMas = GetPositiveLinq(mas);
                sw.Stop();
                ticks.Add(sw.ElapsedTicks);
            }

            ticks.Sort();
            Console.WriteLine("\nТики:");
            foreach (var item in ticks)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nМедиана: {0}", ticks[ticks.Count / 2]);

            Console.ReadKey();
        }
    }
}