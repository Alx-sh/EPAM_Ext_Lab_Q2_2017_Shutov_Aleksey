namespace Task04
{
    abstract class Bonuses : Field
    {
        public Bonuses(int x, int y)
        {
            States[x, y] = FieldState.Bonus;
        }

        /// <summary>
        /// Бонус для игрока.
        /// </summary>
        public abstract void Raising(Player p);
    }
}