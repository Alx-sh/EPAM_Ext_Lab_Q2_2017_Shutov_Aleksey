/// <summary>
/// Написать класс Round, задающий круг с указанными координатами центра, радиусом, а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
/// Обеспечить нахождение объекта в заведомо корректном состоянии.
/// Написать программу, демонстрирующую использование данного круга.
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

            Round round1;
            Round round2;
            double length;
            double area;

            round1 = new Round();
            Console.WriteLine("Переопределение значений: x = 3, r = 6\n");
            round1.X = 3;
            //round1.Y = 4; - Ошибка, т.к. модификатор set у переменной int y - private.
            //round1.r = 4.5; - Ошибка, т.к. модификатор double r - private.
            round1.Radius = 6;
            length = round1.GetLength();
            area = round1.GetArea();

            Console.WriteLine("Длина окружности: {0}\nПлощадь окружности: {1}", length, area);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();

            Console.Clear();

            round2 = new Round(1, 2, -4.5);
            length = round2.GetLength();
            area = round2.GetArea();

            Console.WriteLine("Длина окружности: {0}\nПлощадь окружности: {1}", length, area);
            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }
    }
}
