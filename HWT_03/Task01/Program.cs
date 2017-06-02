/// <summary>
/// Написать программу, которая генерирует случайным образом элементы массива (число элементов в массиве и их тип определяются разработчиком), определяет для него максимальное и минимальное значения, сортирует массив и выводит полученный результат на экран.
/// Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) использовать в данном задании запрещается.
/// </summary>
namespace Task01
{
    using System;
    using System.Text;

    class Program
    {
        /// <summary>
        /// Вывод элементов массива на экран.
        /// </summary>
        /// <param name="arr"> Массив. </param>
        static void ShowArray <T> (T [] arr)
        {
            foreach (T x in arr)
            {
                Console.Write(" {0}", x);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Поиск максимального элемента в массиве.
        /// </summary>
        /// <typeparam name="T"> Тип элемента. </typeparam>
        /// <param name="arr"> Массив. </param>
        /// <returns> Максимальное значение в массиве. </returns>
        static T Max <T> (T [] arr) where T : IComparable<T>
        {
            T max = arr[0];

            foreach (T x in arr)
            {
                max = max.CompareTo(x) < 0 ? x : max;
            }

            return max;
        }

        /// <summary>
        /// Поиск минимального элемента в массиве.
        /// </summary>
        /// <typeparam name="T"> Тип элемента. </typeparam>
        /// <param name="arr"> Массив. </param>
        /// <returns> Минимальное значение в массиве. </returns>
        static T Min<T>(T[] arr) where T : IComparable<T>
        {
            T min = arr[0];

            foreach (T x in arr)
            {
                min = min.CompareTo(x) > 0 ? x : min;
            }

            return min;
        }

        /// <summary>
        /// Сортировка массива.
        /// </summary>
        /// <typeparam name="T"> Тип элементов.</typeparam>
        /// <param name="arr"> Массив. </param>
        static void Sort<T>(ref T[] arr) where T : IComparable<T>
        {
            T temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j]) > 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int n = 10;
            int[] arr = new int [n];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }

            Console.WriteLine("Исходный массив:");
            ShowArray(arr);

            Console.WriteLine("Максимальный элемент:\n {0}", Max(arr));
            Console.WriteLine("Минимальный элемент:\n {0}", Min(arr));

            Sort(ref arr);
            Console.WriteLine("Отсортированный массив:");
            ShowArray(arr);

            Console.ReadKey();
        }
    }
}
