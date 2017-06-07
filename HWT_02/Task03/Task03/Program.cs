/// <summary>
/// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран «изображение», состоящее из N строк.
/// </summary>
namespace Task03
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

                if (isInt && N > 0)//Исправил
				{
                    break;
                }

            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j < (N - i); j++)
                {
                    Console.Write("{0}", space);
                }

                for (int j = 0; j < (i * 2 - 1); j++)
                {
                    Console.Write("{0}", sym);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}