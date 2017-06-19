namespace Task03
{
    using System;
    using System.Text;

    /// <summary>
    /// Класс Ring (кольцо), описываемый координатами центра, внешним и внутренним радиусами, а также свойствами, позволяющими узнать площадь кольца и суммарную длину внешней и внутренней границ кольца. 
    /// </summary>
    class Ring : Round
    {
        private Round r1 { get; set; }
        private Round r2 { get; set; }

        public Ring() : base()
        {
            r1 = new Round();
            r2 = new Round();
        }

        public Ring(int x, int y, double radius1, double radius2) : base(x, y, radius1)
        {
            r1 = new Round(x, y, radius1);
            r2 = new Round(x, y, radius2);
        }

        /// <summary>
        /// Сумма длин двух окружностей.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public override double GetLength()
        {
            return r1.GetLength() + r2.GetLength();
        }

        /// <summary>
        /// Площадь кольца.
        /// </summary>
        /// <returns>Вещественное число.</returns>
        public override double GetArea()
        {
            return Math.Abs(r1.GetArea() - r2.GetArea());
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Кольцо:");
            str.Append("\n\tЦентр в точке (" + X + ", " + Y + ")");
            str.Append("\n\tПервый радиус: " + r1.Radius);
            str.Append("\n\tВторой радиус: " + r2.Radius);
            str.Append("\n\tСумма длин двух окружностей: " + GetLength());
            str.Append("\n\tПлощадь кольца: " + GetArea());
            return str.ToString();
        }
    }
}
