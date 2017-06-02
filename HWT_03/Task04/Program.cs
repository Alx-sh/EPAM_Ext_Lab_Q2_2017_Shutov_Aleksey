/// <summary>
/// Элемент двумерного массива считается стоящим на чётной позиции, если сумма номеров его позиций по обеим размерностям является чётным числом (например, [1,1] – чётная позиция, а [1,2] - нет). 
/// Определить сумму элементов массива, стоящих на чётных позициях.
/// </summary>
namespace Task04
{
    using System;
    using System.Text;

    class Program
    {
        static int n = 3; // Количество элементов в одном измерении.

        /// <summary>
        /// Вывод элементов массива на экран.
        /// </summary>
        /// <param name="arr"> Массив. </param>
        static void ShowArray(int[,] arr)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(" {0}", arr[i, j]);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Определяет сумму элементов массива, стоящих на чётных позициях.
        /// </summary>
        /// <param name="arr"> Массив. </param>
        /// <returns> Сумма неотрицательных элементов. </returns>
        static int Sum(int[,] arr)
        {
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum += (i + j) % 2 == 0 ? arr[i, j] : 0;
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int n = 10;
            int[,] arr = new int[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(-100, 100);
                }
            }

            Console.WriteLine("Исходный двумерный массив:");
            ShowArray(arr);

            Console.WriteLine("Сумма элементов массива, стоящих на чётных позициях:\n {0}", Sum(arr));

            Console.ReadKey();
        }
    }
}
