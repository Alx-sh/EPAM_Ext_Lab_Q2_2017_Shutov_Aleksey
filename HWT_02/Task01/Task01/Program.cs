/// <summary>
/// Написать программу, которая определяет площадь прямоугольника со сторонами a и b. 
/// Если пользователь вводит некорректные значения (отрицательные, или 0), должно выдаваться сообщение об ошибке. 
/// Возможность ввода пользователем строки вида «абвгд», или нецелых чисел игнорировать.
/// </summary>
namespace Task01
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int a;
            int b;
            int s;

            while (true)
            {
                Console.Write("Введите длину стороны a:\n a = ");
                a = int.Parse(Console.ReadLine());
                if (a > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректное значение! Введите положительное целое число.");
                }
            }

            while (true)
            {
                Console.Write("Введите длину стороны b:\n b = ");
                b = int.Parse(Console.ReadLine());
                if (b > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректное значение! Введите положительное целое число.");
                }
            }

            s = a * b;

            Console.WriteLine("Площадь прямоугольника равна {0}", s);
            Console.ReadKey();
        }
    }
}