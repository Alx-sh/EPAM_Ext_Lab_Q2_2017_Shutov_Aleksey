namespace Task03
{
    using System;
    using System.Text;

    /// <summary>
    /// Класс, задающий круг с указанными координатами центра, радиусом, а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
    /// </summary>
    class Round : Circle
    {
        public Round() : base()
        {
        }

        public Round(int x, int y, double r) : base(x, y, r)
        {
        }

        /// <summary>
        /// Площадь круга.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public virtual double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Круг:");
            str.Append("\n\tЦентр в точке (" + X + ", " + Y + ")");
            str.Append("\n\tРадиус: " + Radius);
            str.Append("\n\tДлина окружности: " + GetLength());
            str.Append("\n\tПлощадь круга: " + GetArea());
            return str.ToString();
        }
    }
}