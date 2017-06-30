/// <summary>
/// Напишите расширяющий метод, который определяет сумму элементов массива.
/// </summary>
namespace Task01
{
    using System;
    using System.Text;

    public static class DataHelper
    {
        public static int Sum(this int[] param)
        {
            int sum = 0;

            foreach (var item in param)
            {
                sum += item;
            }

            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int[] mas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            Console.WriteLine("Массив:");

            foreach (var item in mas)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nСумма элементов массива: {0}", mas.Sum());
            Console.ReadKey();
        }
    }
}
