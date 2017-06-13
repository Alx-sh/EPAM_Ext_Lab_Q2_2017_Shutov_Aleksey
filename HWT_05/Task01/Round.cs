

namespace Task01
{
    using System;

    /// <summary>
    /// Класс, задающий круг с указанными координатами центра, радиусом, а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
    /// </summary>
    public class Round
    {
        public int X { get; set; }//Продемонстрировал пример работы set и private set в main.
        public int Y { get; private set; }
        private double r = 1;

        public double Radius
        {
            get
            {
                return r;
            }

            set
            {
                if (value > 0)
                {
                    r = value;
                }
                else
                {
                    Console.WriteLine("Недопустимое значение радиуса: {0}. Использовано значение по умолчанию: {1}.\n", value, r);
                }
            }
        }

        public Round()
        {
            Console.WriteLine("Создан конструктор без параметров:\n x = {0}\n y = {1}\n r = {2}", X, Y, r);
        }

        public Round(int x, int y, double r)
        {
            Console.WriteLine("Создан конструктор с параметрами:\n x = {0}\n y = {1}\n r = {2}", X, Y, r);
            X = x;
            Y = y;
            Radius = r;
        }

        /// <summary>
        /// Длина описанной окружности.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public double GetLength()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Площадь круга.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}