/// <summary>
/// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран «изображение», состоящее из N строк.
/// </summary>
namespace Task02
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
                for (int j = 0; j < i; j++)
                {
                    Console.Write("{0}", sym);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}