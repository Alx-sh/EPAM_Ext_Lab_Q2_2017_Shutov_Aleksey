namespace Task04
{
    class Player : Field
    {
        public int Id { get; set; }
        private string Name { get; set; }
        private Professions Prof { get; set; }
        public Stats Stats { get; set; }
        public int Gold { get; set; }

		public Player(int i, string n, Professions p, int x, int y)
        {
            Id = i;
            Name = n;
            Prof = p;
            Stats = new Stats();
            Gold = 100;
            States[x, y] = FieldState.Player;
        }

        /// <summary>
        /// Атака игроком монстра.
        /// </summary>
        /// <param name="m"> Монстр. </param>
        public void Attack(Monsters m) { }

        /// <summary>
        /// Смена статуса и изменение здоровья при ранении, регенерации, смерти.
        /// </summary>
        public void ChangeStatus() { }

        /// <summary>
        /// Ход игрока.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(int x, int y) { }

        /// <summary>
        /// Подбор бонуса.
        /// </summary>
        /// <param name="b"> Бонус. </param>
        public void TakeBonus(Bonuses b) { }

        /// <summary>
        /// Способность игрока.
        /// </summary>
        public void Skill() { }

        public enum Professions
        {
            Guardian,
            Warrior,
            Ranger
        }
    }
}