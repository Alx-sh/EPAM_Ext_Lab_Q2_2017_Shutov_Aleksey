/// <summary>
/// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N треугольников.
/// </summary>
namespace Task04
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int N;
            bool isInt;
            char sym = '*';
            char space = ' ';

            while (true)
            {
                Console.WriteLine("Введите число N:");
                isInt = int.TryParse(Console.ReadLine(), out N);

                if (isInt == true && N > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректное значение! Введите положительное целое число.");
                }
            }

            for (int i = 1; i <= N; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    for (int j = 0; j < (N - k); j++)
                    {
                        Console.Write("{0}", space);
                    }

                    for (int j = 0; j < (k * 2 - 1); j++)
                    {
                        Console.Write("{0}", sym);
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
