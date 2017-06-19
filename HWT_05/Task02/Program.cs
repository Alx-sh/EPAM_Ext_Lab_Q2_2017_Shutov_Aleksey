/// <summary>
/// Написать класс, описывающий треугольник со сторонами a, b, c, и позволяющий осуществить расчёт его площади и периметра. 
/// Написать программу, демонстрирующую использование данного треугольника.
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

            Triangle tr1;
            Triangle tr2;
            double perimeter;
            double area;

            tr1 = new Triangle();
            Console.WriteLine("Переопределение значений: a = -1, b = 0.5, c = -6,2\n");
            tr1.A = -1;
            tr1.B = 0.5;
            tr1.C = -6.2;

            if (tr1.IsTriangle())
            {
                perimeter = tr1.Perimeter;
                area = tr1.GetArea();
                Console.WriteLine("\nПериметр треугольника: {0}\nПлощадь треугольника: {1}", perimeter, area);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();

            Console.Clear();

            tr2 = new Triangle(1.4, 6.5, -1);
            if (tr2.IsTriangle())
            {
                perimeter = tr2.Perimeter;
                area = tr2.GetArea();
                Console.WriteLine("\nПериметр треугольника: {0}\nПлощадь треугольника: {1}", perimeter, area);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }
    }
}