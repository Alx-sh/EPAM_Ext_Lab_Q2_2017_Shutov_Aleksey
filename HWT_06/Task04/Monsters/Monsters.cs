namespace Task04
{
    abstract class Monsters : Field
    {
        public int id { get; set; }
        protected Monster name { get; set; }
        protected Stats stats { get; set; }
        public bool isMoving { get; set; }
        
        public Monsters(int x, int y)
        {
            States[x, y] = FieldState.Monster;
        }

        /// <summary>
        /// Атака монстром по игроку.
        /// </summary>
        /// <param name="p"> Игрок. </param>
        public abstract void Attack(Player p);

        /// <summary>
        /// Награда за убийство.
        /// </summary>
        public abstract void Award(Player p);

        /// <summary>
        /// Смена статуса и изменение здоровья при ранении, регенерации, смерти.
        /// </summary>
        public abstract void ChangeStatus();

        /// <summary>
        /// Ход монстра.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public abstract void Move(int x, int y);

        /// <summary>
        /// Способность монстра.
        /// </summary>
        public abstract void Skill();

        public enum Monster
        {
            Bear,
            Dog,
            Wolf
        }
    }
}