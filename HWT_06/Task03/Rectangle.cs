namespace Task03
{
    using System.Text;

    /// <summary>
    /// Класс, описывающий прямоугольник.
    /// </summary>
    class Rectangle : Line
    {
        private Line l1 { get; set; }
        private Line l2 { get; set; }
        private Line l3 { get; set; }
        private Line l4 { get; set; }

        public Rectangle() : base()
        {
            l1 = new Line();
            l2 = new Line();
            l3 = new Line();
            l4 = new Line();
        }

        public Rectangle(int x, int y, double width, double height, double angle) : base(x, y, width, angle)
        {
            l1 = new Line(x, y, width, angle);
            l2 = new Line(x, y, height, angle - 90);
            l3 = new Line(x, y, width, angle - 180);
            l4 = new Line(x, y, height, angle - 270);
        }

        public override double GetLength()
        {
            return l1.Side + l2.Side + l3.Side + l4.Side;
        }

        public double GetArea()
        {
            return l1.Side * l2.Side;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Прямоугольник:");
            str.Append("\n\tНачинается в точке (" + X + ", " + Y + ")");
            str.Append("\n\tШирина: " + l1.Side);
            str.Append("\n\tВысота: " + l2.Side);
            str.Append("\n\tУгол наклона: " + l1.Angle);
            str.Append("\n\tСумма всех сторон: " + GetLength());
            str.Append("\n\tПлощадь прямоугольника: " + GetArea());
            return str.ToString();
        }
    }
}
