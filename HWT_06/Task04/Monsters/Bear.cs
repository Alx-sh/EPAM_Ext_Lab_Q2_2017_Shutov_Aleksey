﻿namespace Task04
{
    class Bear : Monsters
    {
        public Bear(int x, int y) : base(x, y)
        {
            id = 1;
            name = Monster.Bear;
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