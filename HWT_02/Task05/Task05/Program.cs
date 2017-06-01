/// <summary>
/// Если выписать все натуральные числа меньше 10, кратные 3, или 5, то получим 3, 5, 6 и 9. 
/// Сумма этих чисел будет равна 23. 
/// Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
/// </summary>
namespace Task05
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int sum = 0;

            Console.WriteLine("Сумма всех чисел меньше 1000, кратных 3, или 5:");

            for (int i = 1; i < 1000; i++)
            {
                if (i % 5 == 0 || i % 3 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine("{0}", sum);
            Console.ReadKey();
        }
    }
}