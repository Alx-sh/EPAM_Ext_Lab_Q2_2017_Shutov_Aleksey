namespace Task02
{
    using System;

    /// <summary>
    /// Класс Ring (кольцо), описываемый координатами центра, внешним и внутренним радиусами, а также свойствами, позволяющими узнать площадь кольца и суммарную длину внешней и внутренней границ кольца. 
    /// </summary>
    class Ring : Round
    {
        public Round r1;
        public Round r2;

        public Ring()
        {
            r1 = new Round();
            r2 = new Round();
        }

        public Ring(int x, int y, double radius1, double radius2)
        {
            X = x;
            Y = y;
            r1 = new Round(radius1);
            r2 = new Round(radius2);
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
    }
}
