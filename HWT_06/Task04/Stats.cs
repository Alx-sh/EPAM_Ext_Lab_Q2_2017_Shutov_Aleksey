namespace Task04
{
    class Stats
    {
        public int Level { get; private set; }
        public int Experience { get; set; }
        public int HealthPoint { get; set; }
        public int ManaPoint { get; set; }
        public int Armor { get; set; }
        public int MovedSpeed { get; set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Intelligence { get; private set; }
        public double RegenerationHP { get; set; }
        public double RegenerationMP { get; set; }
        public int Damage { get; set; }
        public Status Stat { get; set; }

        public Stats()
        {
            Experience = 0;
            HealthPoint = 300;
            ManaPoint = 150;
            MovedSpeed = 1;
            Strength = 10;
            Agility = 10;
            Intelligence = 10;
            Damage = 20;
            CalculateRegen(Strength, Intelligence);
            CalculateLevel(Experience);
            CalculateArmor(Agility);
        }

        public Stats(int exp, int hp, int mp, int ms, int s, int a, int i, int dmg, Status st)
        {
            Experience = exp;
            HealthPoint = hp;
            ManaPoint = mp;
            MovedSpeed = ms;
            Strength = s;
            Agility = a;
            Intelligence = i;
            Damage = dmg;
            Stat = st;
            CalculateRegen(Strength, Intelligence);
            CalculateLevel(Experience);
            CalculateArmor(Agility);
        }

        public void CalculateRegen(int strength, int intelligence) { }

        public void CalculateLevel(int experience) { }

        public void CalculateArmor(int agility) { }

        public enum Status
        {
            Healthy,
            Wounded,
            Dead
        }
    }
}