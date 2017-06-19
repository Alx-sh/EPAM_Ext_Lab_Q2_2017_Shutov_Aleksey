namespace Task02
{
    using System;

    /// <summary>
    /// Класс, описывающий треугольник со сторонами a, b, c, и позволяющий осуществить расчёт его площади и периметра. 
    /// </summary>
    class Triangle
    {
        private double a;
        private double b;
        private double c;

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
                    a = 1;
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
                    b = 1;
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
                    c = 1;
                    Console.WriteLine("Недопустимое значение: {0}. Использовано значение по умолчанию: {1}.", value, c);
                }

                Console.WriteLine("Значение для стороны c =  {0}", c);
            }
        }

        /// <summary>
        /// Периметр треугольника.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public double Perimeter
        {
            get
            {
                return A + B + C;
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
            if (A + B <= C || A + C <= B || B + C <= A || A == 0 || B == 0 || C == 0)
            {
                Console.WriteLine("\nТреугольника с такими сторонами не существует!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Площадь треугольника.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public double GetArea()
        {
            double p = Perimeter / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}