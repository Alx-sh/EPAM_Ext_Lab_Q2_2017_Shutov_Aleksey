using System;
using System.Text;

namespace Task02
{
    /// <summary>
    /// Дано действительное число h. Выяснить, имеет ли уравнение ax^2 + bx + c = 0 действительное корни, 
    /// если определены a, b, c, и если существуют, то найти их.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            double a;
            double b;
            double c;
            double D;
            double h;
            double x1;
            double x2;
            bool isDouble;

            Console.WriteLine("Введите действительное число h:");
            while (true)
            {
                Console.Write("h = ");
                isDouble = double.TryParse(Console.ReadLine(), out h);
                if (isDouble == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Не верный формат входной строки! Введите действительное или целое число.");
                }
            }

            a = Math.Sqrt(((Math.Abs(Math.Sin(8 * h))) + 17) / (Math.Pow(1 - Math.Sin(4 * h) * Math.Cos(Math.Pow(h, 2) + 18), 2)));
            b = 1 - Math.Sqrt(3 / (3 + Math.Abs(Math.Tan(a * Math.Pow(h, 2)) - Math.Sin(a * h))));
            c = a * Math.Pow(h, 2) * Math.Sin(b * h) + (b * Math.Pow(h, 3)) * Math.Cos(a * h);
            D = Math.Pow(b, 2) - 4 * a * c;

            Console.WriteLine("a = {0}\nb = {1}\nc = {2}\nD = {3}", a, b, c, D);

            if (D >= 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);

                Console.WriteLine(x1 == x2 ? "Корень уравнения:\nx1 = {0}" : "Корни уравнения:\nx1 = {0}\nx2 = {1}", x1, x2);
            }
            else
            {
                Console.WriteLine("Корней нет");
            }

            Console.ReadKey();
        }
    }
}