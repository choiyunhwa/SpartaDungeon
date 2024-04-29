internal class Warrior : IPlayer
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; set; }
    public float Atk { get; set; }
    public float AddAtk { get; set; }
    public float Def { get; set; }
    public float AddDef { get; set; }
    public int MaxHp { get; set; }
    public int CurrentHp { get; set; }
    public int MaxMana { get; set; }
    public int CrrentMana { get; set; }
    public int Gold { get; set; }
    public int Experience { get; set; }

    public Warrior(string name, string job, int level, float atk, float def, int mexHp, int mexmana, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        MaxHp = mexHp;
        MaxMana = mexmana;
        Gold = gold;
        CurrentHp = MaxHp;
        CrrentMana = MaxMana;
        AddAtk = 0;
        AddDef = 0;
        Experience = 0;
    }

    public void GetGold(int coin)
    {
        Gold += coin;
    }

    public void LevelUp()
    {
        if (Experience >= Level * (Level + 1) / 2 * 10) //레벨업 공식
        {
            Level++;
            Atk += 1;
            Def += 1;
            MaxHp += 10;
            CurrentHp = MaxHp;
            Console.WriteLine($"{Name}님의 레벨이 {Level}로 올랐습니다!");
        }
    }

    public void GainExperience(int exp)
    {
        Experience += exp;
        LevelUp();
    }



}
