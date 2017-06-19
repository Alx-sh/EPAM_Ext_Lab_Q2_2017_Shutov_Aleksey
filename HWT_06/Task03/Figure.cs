namespace Task03
{
    /// <summary>
    /// Абстрактный класс фигур.
    /// </summary>
    abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Figure()
        {
            X = Y = 0;
        }

        public Figure(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract double GetLength();
    }
}
