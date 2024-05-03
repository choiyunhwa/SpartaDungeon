﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Minion : IEnemy
{
    public String name { get; set; }
    public int level { get; set; }
    public int currentHP { get; set; }
    public int maxHP { get; set; }
    public int damage { get; set; }
    public bool isDead { get; set; }

    public Minion()
    {
        name = "미니언";
        level = 3;
        maxHP = 10;
        currentHP = 10;
        damage = 5;
        isDead = false;
    }
    
    public int Attack()
    {
        Random flag = new Random();
        int result = flag.Next(0, 100);

        if (80 <= result)
        {
            return 0;
        }

        else if (70 <= result && result < 79)
        {
            return (int)(damage * 1.2);
        }

        else
        {
            int range = (int)(((float)damage / 10) + 0.5);
            Random rand = new Random();
            return rand.Next(damage - range, damage + range + 1);
        }
    }

    public bool Die()
    {
        if (currentHP == 0)
            return true;

        else return false;
    }

    public Reward GetReward()
    {
        return new Reward { gold = 50, exp = 10 };
    }

    public IEnemy DeepCopy()
    {
        Minion other = (Minion) this.MemberwiseClone();
        other.name = this.name;
        other.level = this.level;
        other.maxHP = this.maxHP;
        other.currentHP = this.currentHP;
        other.damage = this.damage;
        other.isDead = this.isDead;

        return other;
    }
}

