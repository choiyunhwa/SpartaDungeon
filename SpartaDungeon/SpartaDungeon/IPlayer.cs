namespace SpartaDungeon
{
    public interface IPlayer
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public float Atk { get; }
        public float Def { get; }
        public int MaxHp { get; }
        public int CourrentHp { get; }
        public int MaxMana { get; }
        public int CorrentMana { get; }
        public int Gold { get; set; }
        public int Experience { get; set; }

        public void LevelUP();
        public void GainExperience(int exp);
    }
}


