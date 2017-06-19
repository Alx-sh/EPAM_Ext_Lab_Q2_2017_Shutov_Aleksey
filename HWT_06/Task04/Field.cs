namespace Task04
{
    class Field
    {
        private int Width { get; set; }
        private int Height { get; set; }
        public FieldState[,] States;

        public Field()
        {
            Width = 10;
            Height = 10;
            States = new FieldState[Width, Height];
            FillField();
        }

        public Field(int w, int h)
        {
            Width = w;
            Height = h;
            States = new FieldState[Width, Height];
            FillField();
        }

        /// <summary>
        /// Заполнение игрового поля (для примера заполнил пустыми ячейками).
        /// </summary>
        public void FillField()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    States[i, j] = FieldState.Empty;
                }
            }
        }
        

        /// <summary>
        /// Изменение игрового поля после хода.
        /// </summary>
        public void GameMove() { }

        /// <summary>
        /// Проверка наличия бонусов на поле.
        /// </summary>
        /// <returns></returns>
        public bool NoBonuses() 
        {
            foreach (var st in States)
            {
                if (st == FieldState.Bonus)
                {
                    return false;
                }
            }

            return true;
        }

        public enum FieldState
        {
            Empty,
            Obstacle,
            Bonus,
            Monster,
            Player
        }
    }
}