namespace Task02
{
    using System;

    /// <summary>
    /// Класс, задающий круг с указанными координатами центра, радиусом, а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
    /// </summary>
    class Round
    {
        public int X { get; set; }
        public int Y { get; set; }
        private double r;

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
            X = Y = 0;
            Radius = 1;
        }

        public Round(double r)
        {
            X = Y = 0;
            Radius = r;
        }

        /// <summary>
        /// Длина описанной окружности.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public virtual double GetLength()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Площадь круга.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public virtual double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}