using System;
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
        level = 2;
        maxHP = 15;
        currentHP = 15;
        damage = 5;
        isDead = false;
    }

    public int Attack()
    {
        int range = (int)(((float)damage / 10) + 0.5);
        Random rand = new Random();
        return rand.Next(damage - range, damage + range + 1);
    }

    public bool Die()
    {
        if (currentHP == 0)
            return true;

        else return false;
    }
}

