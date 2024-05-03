using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Voidling : IEnemy
{
    public String name { get; set; }
    public int level { get; set; }
    public int currentHP { get; set; }
    public int maxHP { get; set; }
    public int damage { get; set; }
    public bool isDead { get; set; }

    public Voidling()
    {
        name = "공허충";
        level = 2;
        maxHP = 5;
        currentHP = 5;
        damage = 3;
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
        return new Reward { gold = 30, exp = 7 };
    }

    public IEnemy DeepCopy()
    {
        Voidling other = (Voidling)this.MemberwiseClone();
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
        allQuestList.killVoidling.OnKilledEnemy(name);
    }
}

