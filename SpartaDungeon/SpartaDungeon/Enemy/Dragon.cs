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

    public event IsAttack AttackInfor;

    EAttackInfor eAttackInfor;
    public Dragon()
    {
        name = "드래곤";
        level = 10;
        maxHP = 50;
        currentHP = 50;
        damage = 20;
        isDead = false;
    }
    public int Attack()
    { 
        Random flag = new Random();         // 10퍼센트의 공격 빗나감, 15퍼센트의 치명타 공격, 일반 공격을 구분하기 위한 랜덤 함수
        int result = flag.Next(0, 100);
        int damage = 0;

        if (90 <= result)       // 몬스터의 공격 빗나감 - 0데미지 반한
        {

            damage = 0;
            //return damage;
        }

        else if (75 <= result && result < 90)       // 몬스터의 치명타 공격 - 기본 damage 함수의 1.5배 데미지 반환
        {
            damage = (int)(damage * 1.5);
            //return damage;
        }

        else
        {
            int range = (int)(((float)damage / 10) + 0.5);      // 일반 공격 - 몬스터의 공격력에 따른 오차가 존재하며, 이 오차 내에서 데미지 도출 후 반환.
            Random rand = new Random();
            damage = rand.Next(damage - range, damage + range + 1);
            //return damage;
        }

        //AttackInfor += OnAttack(EAttackInfor.BASIC, damage);

        return damage;
    }

    public void OnAttack(EAttackInfor _attackInfor, int _damage)
    {
        EAttackInfor eAttackInfor = _attackInfor;
        int damage = _damage;
    }

    public bool Die()
    {
        if (currentHP == 0)
            return true;

        else return false;
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
}

