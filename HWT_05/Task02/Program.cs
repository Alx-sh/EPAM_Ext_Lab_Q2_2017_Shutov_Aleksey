/// <summary>
/// Написать класс, описывающий треугольник со сторонами a, b, c, и позволяющий осуществить расчёт его площади и периметра. 
/// Написать программу, демонстрирующую использование данного треугольника.
/// </summary>
namespace Task02
{
    using System;
    using System.Text;

    class Triangle
    {
        private double a = 1;
        private double b = 1;
        private double c = 1;

        public double A
        {
            get
            {
                return a;
            }

            set
            {
                if (value > 0)
                {
                    a = value;
                }
                else
                {
                    Console.WriteLine("Недопустимое значение: {0}. Использовано значение по умолчанию: {1}.", value, a);
                }

                Console.WriteLine("Значение для стороны a =  {0}", a);
            }
        }

        public double B
        {
            get
            {
                return b;
            }

            set
            {
                if (value > 0)
                {
                    b = value;
                }
                else
                {
                    Console.WriteLine("Недопустимое значение: {0}. Использовано значение по умолчанию: {1}.", value, b);
                }

                Console.WriteLine("Значение для стороны b =  {0}", b);
            }
        }

        public double C
        {
            get
            {
                return c;
            }

            set
            {
                if (value > 0)
                {
                    c = value;
                }
                else
                {
                    Console.WriteLine("Недопустимое значение: {0}. Использовано значение по умолчанию: {1}.", value, c);
                }

                Console.WriteLine("Значение для стороны c =  {0}", c);
            }
        }

        public Triangle()
        {
            Console.WriteLine("Создан конструктор без параметров:\n a = {0}\n b = {1}\n c = {2}", a, b, c);
        }

        public Triangle(double a, double b, double c)
        {
            Console.WriteLine("Создан конструктор с параметрами:\n a = {0}\n b = {1}\n c = {2}", a, b, c);
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Проверка, является ли фигура треугольником.
        /// </summary>
        /// <returns>Булево значение.</returns>
        public bool IsTriangle()
        {
            if (a + b <= c || a + c <= b || b + c <= a || a == 0 || b == 0 || c == 0)
            {
                Console.WriteLine("\nТреугольника с такими сторонами не существует!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Периметр треугольника.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public double GetPerimeter()
        {
            return a + b + c;
        }

        /// <summary>
        /// Площадь треугольника.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

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
                perimeter = tr1.GetPerimeter();
                area = tr1.GetArea();
                Console.WriteLine("\nПериметр треугольника: {0}\nПлощадь треугольника: {1}", perimeter, area);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();

            Console.Clear();

            tr2 = new Triangle(1.4, 6.5, -1);
            if (tr2.IsTriangle())
            {
                perimeter = tr2.GetPerimeter();
                area = tr2.GetArea();
                Console.WriteLine("\nПериметр треугольника: {0}\nПлощадь треугольника: {1}", perimeter, area);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }
    }
}