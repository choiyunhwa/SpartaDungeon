﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Baron : IEnemy
{
    public String name { get; set; }
    public int level { get; set; }
    public int currentHP { get; set; }
    public int maxHP { get; set; }
    public int damage { get; set; }
    public bool isDead { get; set; }
    public int currentDamage { get; set; }
    public EAttackInfor eAttackInfor { get; set; }
    public Baron()
    {
        name = "바론";
        level = 8;
        maxHP = 60;
        currentHP = 60;
        damage = 10;
        isDead = false;
    }

    public int Attack()
    {
        Random flag = new Random();
        int result = flag.Next(0, 100);
        int damage = 0;

        if (80 <= result)
        {
            eAttackInfor = EAttackInfor.NONE;
            currentDamage = 0;
            return currentDamage;
        }

        else if (70 <= result && result < 79)
        {
            eAttackInfor = EAttackInfor.CRITICAL;
            currentDamage = (int)(damage * 1.2);
            return currentDamage;
        }

        else
        {
            eAttackInfor = EAttackInfor.BASIC;
            int range = (int)(((float)damage / 10) + 0.5);
            Random rand = new Random();
            currentDamage = rand.Next(damage - range, damage + range + 1);
            return currentDamage;
        }
    }

    public bool Die()
    {
        if (currentHP == 0)
        {
            return true;
        }
        else return false;
    }

    public Reward GetReward()
    {
        return new Reward { gold = 50, exp = 10 };
    }

    public IEnemy DeepCopy()
    {
        Minion other = (Minion)this.MemberwiseClone();
        other.name = this.name;
        other.level = this.level;
        other.maxHP = this.maxHP;
        other.currentHP = this.currentHP;
        other.damage = this.damage;
        other.isDead = this.isDead;

        return other;
    }

    public void CallOnKilled(AllQuestList allQuestList)
    {
        if (allQuestList.acceptedQuestsLis.Count != 0)
        {
            foreach (var name in allQuestList.acceptedQuestsLis)
            {
                name.OnKilledEnemy(this.name);
            }
        }
    }
}
