/// <summary>
/// Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули. 
/// Число элементов в массиве и их тип определяются разработчиком.
/// </summary>
namespace Task02
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
        static void ShowArray(int[,,] arr)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write(" {0}", arr[i, j, k]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Замена положительных элементов нулями.
        /// </summary>
        /// <param name="arr"> Массив. </param>
        static void ChangeElements(ref int[,,] arr)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        arr[i, j, k] = arr[i, j, k] > 0 ? 0 : arr[i, j, k];
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int[,,] arr = new int[n, n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        arr[i, j, k] = rnd.Next(-100, 100);
                    }
                }
            }

            Console.WriteLine("Исходный трехмерный массив:");
            ShowArray(arr);

            Console.ReadKey();//todo pn нужно было сообщение хотя бы вывести, чтобы пользователь что-нибудь нажал, а то не очень понятно, что делать.

            ChangeElements(ref arr);
            Console.WriteLine("Массив, после замены положительных элементов нулями:");
            ShowArray(arr);

            Console.ReadKey();
        }
    }
}
