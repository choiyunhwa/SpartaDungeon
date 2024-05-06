using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


public class Dragon : IEnemy
{
    public String name { get; set; }
    public int level { get; set; }
    public int currentHP { get; set; }
    public int maxHP { get; set; }
    public int damage { get; set; }
    public bool isDead { get; set; }

    public int currentDamage { get; set; }
    public EAttackInfor eAttackInfor { get; set; }
    public Dragon()
    {
        name = "드래곤";
        level = 7;
        maxHP = 20;
        currentHP = 20;
        damage = 10;
        isDead = false;
    }
    public int Attack()
    { 
        Random flag = new Random();         // 20퍼센트의 공격 빗나감, 10퍼센트의 치명타 공격, 70 퍼센트의 일반 공격을 구분하기 위한 랜덤 변수
        int result = flag.Next(0, 100);

        if (80 <= result)       // 몬스터의 공격 빗나감 - 0데미지 반환
        {
            eAttackInfor = EAttackInfor.NONE;
            currentDamage = 0;
            return currentDamage;
        }

        else if (70 <= result && result < 79)       // 몬스터의 치명타 공격 - 기본 damage 변수값의 1.2배 데미지 반환
        {
            eAttackInfor = EAttackInfor.CRITICAL;
            currentDamage = (int)(damage * 1.2);
            return currentDamage;
        }

        else
        {
            eAttackInfor = EAttackInfor.BASIC;

            int range = (int)(((float)damage / 10) + 0.5);      // 일반 공격 - 몬스터의 공격력에 따른 오차가 존재하며, 이 오차 내에서 데미지 도출 후 반환.
            Random rand = new Random();
            currentDamage = rand.Next(damage - range, damage + range + 1);
            return currentDamage;
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
        return new Reward { gold = 100, exp = 20 };
    }

    public IEnemy DeepCopy()
    {
        Dragon other = (Dragon)this.MemberwiseClone();
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

