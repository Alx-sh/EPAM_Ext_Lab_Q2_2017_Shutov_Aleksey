namespace Task04
{
    abstract class Obstacle : Field
    {
        public Obstacle(int x, int y)
        {
            States[x, y] = FieldState.Obstacle;
        }

        /// <summary>
        /// Наносимый урон игроку, при попытке приодолеть препятствие.
        /// </summary>
        public abstract void Damage(Player p);
    }
}