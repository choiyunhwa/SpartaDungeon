using System;
using System.Collections.Generic;
using static IPlayer;

public class Skill
{
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
        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write($"{idx}. ");
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

        Console.Write(" -  MP ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(Mana);
        Console.ResetColor();
        Console.WriteLine("");
        Console.Write("     ");
        Console.WriteLine(Description);
    }


    public void UseSkill(List<IEnemy> enemies) // 해금이됬는가->마나가 있는가->실패가능성있는스킬인가->랜덤스킬인가
    {
        if (!Unlocked)
        {
            Console.WriteLine("스킬이 해금되지 않았습니다.");
            //다시 이전으로 돌아가기 구현해야됨 ---------- 
        }
        else
        {
            if(GameScene.player.CurrentMP >= Mana)
            {
                if (CanAttack())
                {
                    if (IsRandom)
                    {
                        RandomAttack();
                    }
                    else
                    {
                        //선택해서 공격
                    }
                }
                else
                {
                    Console.WriteLine("공격에 실패했습니다.");
                    //다시 이전으로 돌아가기 구현해야됨 ----------
                }
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
                //다시 이전으로 돌아가기 구현해야됨 ----------
            }
        }

    }

    public float CalculateDamage()
    {

        float damage = 0;
        damage = GameScene.player.Atk * Damage;

        return damage;
    }

    public void RandomAttack()              //랜덤스킬 구현
    {
        /*Random random = new Random();
        List<IEnemy> shuffledEnemies = competeEnemys.OrderBy(e => random.Next()).ToList();
        List<IEnemy> selectedEnemies = shuffledEnemies.Take(2).ToList();
        foreach (IEnemy enemy in selectedEnemies)
        {
            // enemy.currentHP -= CalculateDamage();
        }*/
    }

    public bool CanAttack()                          //실패할 수 있는 스킬 구현
    {
        Random random = new Random();
        if (CanFaild)
        {
            int randomValue = random.Next(100);

            if (randomValue < 50)
            {
                return false; 
            }
        }

        return true;

    }

}
