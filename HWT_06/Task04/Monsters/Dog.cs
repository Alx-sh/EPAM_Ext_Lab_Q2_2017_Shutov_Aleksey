namespace Task04
{
    class Dog : Monsters
    {
        public Dog(int x, int y) : base(x, y)
        {
            id = 3;
            name = "Собака";
            stats = new Stats();
            status = "Здорова";
            isMoving = true;
        }

        public override void Attack(Player p) { }

        public override void Award(Player p) { }

        public override void ChangeStatus() { }

        public override void Move(int x, int y) { }

        public override void Skill() { }
    }
}