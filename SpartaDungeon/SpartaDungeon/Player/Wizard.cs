public class Wizard : IPlayer
{
    private List<Skill> wizardSkill;


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

        public Wizard(string name, string job, int level, float atk, float def, int mexHp, int mexmana, int gold)
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

            foreach (Skill skill in wizardSkill)
            {
                skill.UnlockSkill(Level);
            }
        }
    }

    public void GainExperience(int exp)
    {
        Experience += exp;
        LevelUp();
    }

    public void SkillList()
    {
        wizardSkill = new List<Skill>();
        wizardSkill.Add(new Skill("에너지 볼트", 3, 1, 10, "공격력 * 3 로 하나의 적을 공격합니다. ◈2레벨에 해금◈", 2, false, false));
        wizardSkill.Add(new Skill("메직 클로", 2.5f, 2, 15, "공격력 * 2.5 로 2명의 적을 랜덤으로 공격합니다. ◈3레벨에 해금◈", 3, true, false));
        wizardSkill.Add(new Skill("콜드 빔", 2, 3, 20, "공격력 * 2 로 3명의 적을 랜덤으로 공격합니다. ◈4레벨에 해금◈", 4, true, false));
        wizardSkill.Add(new Skill("썬더 볼트", 4, 1, 20, "공격력 * 4 로 하나의 적을 공격합니다. (50%의 확률로 공격에 실패) ◈5레벨에 해금◈", 5 , false, true));
    }


}

