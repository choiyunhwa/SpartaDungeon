using System;

internal class Skill
{
    private ChoiseJob choiseJob;
    public string Name { get; set; }
    public float Damage { get; set; }
    public int HitCount { get; set; }
    public int Mana {  get; set; }
    public string Description { get; set; }
    public bool Unlocked { get; set; }
    public int UnlockLevel { get; set; }
    public bool CanFaild { get; set; }
    public bool IsRandom { get; set; }

    public Skill(string name, float damage, int hitCount, int mana, string description, int unlockLevel, bool isRandom, bool canFaild)
    {
        Name = name;
        Damage = damage;
        HitCount = hitCount;
        Mana = mana;
        Description = description;
        Unlocked = false;
        UnlockLevel = unlockLevel;
        IsRandom = isRandom;
        CanFaild = canFaild;

    }


    public void UnlockSkill(int playerLevel)
    {
        if (playerLevel >= UnlockLevel)
        {
            Unlocked = true;  
        }
    }

    public void PrintSkillDescription(int idx = 0)
    {
        Console.Write("- ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write($"{idx} ");
        Console.ResetColor();
        if (Unlocked)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("U");
            Console.ResetColor();
            Console.Write("]");
            Console.Write(ConsoleUtility.PadRightForMixedText(Name, 9));
        }
        else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 12));

        Console.Write(" - ");
        Console.Write(Mana);
        Console.WriteLine("");
        Console.Write(Description);
    }


    public void UseSkill(List<IEnemy> enemies) // 해금이됬는가->마나가 있는가->랜덤스킬인가->실패가능성있는스킬인가
    {
        if (!Unlocked)
        {
            //
        }
        else
        {
            //
        }

    }

    public float CalculateDamage()
    {

        float damage = 0;

        if (choiseJob != null)
        {
            if (choiseJob.Warrior != null)                // 전사의 경우
            {
                damage = choiseJob.Warrior.Atk * Damage;
            }
            else if (choiseJob.Wizard != null)                // 마법사의 경우
            {
                damage = choiseJob.Wizard.Atk * Damage;
            }
        }

        return damage;
    }

    public void RandomAttack(List<IEnemy> enemies)              //랜덤스킬 구현
    {
        
        Random random = new Random();
        List<IEnemy> shuffledEnemies = enemies.OrderBy(e => random.Next()).ToList();
        List<IEnemy> selectedEnemies = shuffledEnemies.Take(2).ToList();
        foreach (IEnemy enemy in enemies)
        {
            //
        }
    }

    public float AttackFailed()                          //실패할 수 있는 스킬 구현
    {
        Random random = new Random();
        if (CanFaild)
        {
            int randomValue = random.Next(100);

            if (randomValue < 50)
            {
                Console.WriteLine("공격에 실패했습니다.");
                return 0; 
            }
        }
        
        return CalculateDamage();

    }

}
