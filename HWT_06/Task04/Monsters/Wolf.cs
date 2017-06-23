namespace Task04
{
    class Wolf : Monsters
    {
        public Wolf(int x, int y) : base(x, y)
        {
            id = 2;
            name = Monster.Wolf;
            stats = new Stats();
            isMoving = true;
        }

        public override void Attack(Player p) { }

        public override void Award(Player p) { }

        public override void ChangeStatus() { }

        public override void Move(int x, int y) { }

        public override void Skill() { }
    }
}