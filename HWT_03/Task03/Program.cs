/// <summary>
/// Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
/// Число элементов в массиве и их тип определяются разработчиком.
/// </summary>
namespace Task03
{
    using System;
    using System.Text;

    class Program
    {
        /// <summary>
        /// Вывод элементов массива на экран.
        /// </summary>
        /// <param name="arr"> Массив. </param>
        static void ShowArray<T>(T[] arr)
        {
            foreach (T x in arr)
            {
                Console.Write(" {0}", x);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Определяет сумму неотрицательных элементов в одномерном массиве.
        /// </summary>
        /// <param name="arr"> Массив. </param>
        /// <returns> Сумма неотрицательных элементов. </returns>
        static int Sum(int[] arr)
        {
            int sum = 0;

            foreach (int x in arr)
            {
                sum += x > 0 ? x : 0;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int n = 10;
            int[] arr = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }

            Console.WriteLine("Исходный массив:");
            ShowArray(arr);

            Console.WriteLine("Сумма неотрицательных элементов массива:\n {0}", Sum(arr));

            Console.ReadKey();
        }
    }
}
