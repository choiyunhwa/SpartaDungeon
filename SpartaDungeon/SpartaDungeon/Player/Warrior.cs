
using static TryEquipment;

public class Warrior : IPlayer
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
    public int MaxMP { get; set; }
    public int CurrentMP { get; set; }
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
        MaxMP = mexmana;
        Gold = gold;
        CurrentHp = MaxHp;
        CurrentMP = MaxMP;

        AddAtk = 0;
        AddDef = 0;
        Experience = 0;
        jobskills();
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

            foreach (Skill skill in GameScene.SkillList)
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

    public void UsePotion() //포션 사용으로 체력 회복
    {
        CurrentHp += 30;
        if (CurrentHp > MaxHp) CurrentHp = MaxHp;
        Console.WriteLine($"포션을 사용했습니다. (현재 체력 : {CurrentHp})");
        Thread.Sleep(500);
    }

    public void jobskills()
    {
        GameScene.SkillList.Add(new Skill("알파 스트라이크", 2, 1, 10, "공격력 * 2 로 하나의 적을 공격합니다. ◈2레벨에 해금◈", 2, false, false));
        GameScene.SkillList.Add(new Skill("더블 스트라이크", 1, 2, 15, "공격력 * 1 데미지로 2명의 적을 랜덤으로 공격합니다. ◈3레벨에 해금◈", 3, true, false));
        GameScene.SkillList.Add(new Skill("파워 스트라이크", 3, 1, 20, "공격력 * 3 데미지로 하나의 적을 공격합니다. (50%의 확률로 공격에 실패) ◈4레벨에 해금◈", 4, false, true));
        GameScene.SkillList.Add(new Skill("파이널 어택", 2, 2, 25, "공격력 * 2 데미지로 2명의 적을 랜덤으로 공격합니다. (50%의 확률로 공격에 실패) ◈5레벨에 해금◈", 5, true, true));

    }

}


