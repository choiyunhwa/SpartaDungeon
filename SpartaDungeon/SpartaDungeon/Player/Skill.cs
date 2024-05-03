using System;
using System.Collections.Generic;
using static IPlayer;

public class Skill
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int HitCount { get; set; }
    public int Mana {  get; set; }
    public string Description { get; set; }
    public bool Unlocked { get; set; }
    public int UnlockLevel { get; set; }
    public bool CanFaild { get; set; }
    public bool IsRandom { get; set; }


    public Skill(string name, int damage, int hitCount, int mana, string description, int unlockLevel, bool isRandom, bool canFaild)
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

    public int CalculateDamage()
    {

        int damage = 0;
        damage = (int)GameScene.player.Atk * Damage;

        return damage;
    }
   
   
    public bool CanAttack()                          //실패할 수 있는 스킬 구현
    {
        Random random = new Random();                //참이면 50%로 실패
        if (CanFaild)
        {
            int randomValue = random.Next(100);

            if (randomValue < 50)
            {
                return false; 
            }
            else
            {
                return true;
            }
        }

        return true;

    }

}
