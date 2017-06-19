namespace Task03
{
    using System;
    using System.Text;

    /// <summary>
    /// Класс, описывающий линию.
    /// </summary>
    class Line : Figure
    {    
        private double side;
        private double angle;

        public double Side
        {
            get
            {
                return side;
            }

            set
            {
                if (value > 0)
                {
                    side = value;
                }
                else
                {
                    side = 1;
                    Console.WriteLine("Недопустимое значение: {0}. Использовано значение по умолчанию: {1}.", value, side);
                }

                Console.WriteLine("Значение для стороны a =  {0}", side);
            }
        }

        public double Angle
        {
            get
            {
                return angle;
            }

            set
            {
                if (value >= 0 && value <= 360)
                {
                    angle = value;
                }
                else
                {
                    if (value >= -360 && value < 0)
                    {
                        angle = 360 + value;
                    }
                    else
                    {
                        angle = 0;
                        Console.WriteLine("Недопустимое значение: {0}. Использовано значение по умолчанию: {1}.", value, side);
                    }
                }
            }
        }

        public Line() : base()
        {
            Side = 1;
            Angle = 0;
        }

        public Line(int x, int y, double s, double angle) : base(x, y)
        {
            Side = s;
            Angle = angle;
        }

        public override double GetLength()
        {
            return Side;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Линия:");
            str.Append("\n\tНачинается в точке (" + X + ", " + Y + ")");
            str.Append("\n\tДлина: " + Side);
            str.Append("\n\tУгол наклона: " + Angle);
            return str.ToString();
        }
    }
}
