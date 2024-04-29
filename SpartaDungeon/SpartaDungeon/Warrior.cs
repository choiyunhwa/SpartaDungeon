internal class Warrior
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public float Atk { get; }
    public float AddAtk { get; set; }
    public float Def { get; }
    public float AddDef { get; }
    public int MaxHp { get; }
    public int CourrentHp { get; }
    public int MaxMana {  get; }
    public int CorrentMana { get; }
    public int Gold { get; set; }
    public int Experience { get; private set; }


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
        CourrentHp = MaxHp;
        CorrentMana = MaxMana;
        AddAtk = 0;
        AddDef = 0;
        Experience = 0;
    }
    
    public void AddAttack()
    {

    }

    public void AddDefense()
    {

    }


    //public void LevelUP()
    //{
    //    if (Experience >= Level * (Level + 1) / 2 * 10) //레벨업 공식
    //    {
    //        Level++;
    //        Attack += 1;
    //        Defense += 1;
    //        MaxHp += 10;    // 레벨업시 최대 체력 증가
    //        CurrentHp = MaxHp;   // 현재 체력도 최대 체력으로 설정
    //        Console.WriteLine($"{Name}님의 레벨이 {Level}로 올랐습니다!");
    //    }
    //}

    //public void GainExperience(int exp)
    //{
    //    Experience += exp;
    //    LevelUp();
    //}



}
