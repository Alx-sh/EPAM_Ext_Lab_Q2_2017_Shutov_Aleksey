namespace Task03
{
    using System;
    using System.Text;

    /// <summary>
    /// Класс, задающий окружность.
    /// </summary>
    class Circle : Figure
    {
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

        public Circle() : base()
        {
            Radius = 1;
        }

        public Circle(int x, int y, double r) : base(x, y)
        {
            Radius = r;
        }

        /// <summary>
        /// Длина описанной окружности.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public override double GetLength()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Окружность:");
            str.Append("\n\tЦентр в точке (" + X + ", " + Y + ")");
            str.Append("\n\tРадиус: " + Radius);
            str.Append("\n\tДлина описанной окружности: " + GetLength());
            return str.ToString();
        }
    }
}
