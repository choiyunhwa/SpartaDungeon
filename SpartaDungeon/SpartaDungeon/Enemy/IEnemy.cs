using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void IsAttack(EAttackInfor attackInfor, int damage);
public interface IEnemy
{
    String name { get; set; }
    int level { get; set; }
    int currentHP { get; set; }
    int maxHP { get; set; }
    int damage { get; set; }
    bool isDead { get; set; }    

    int Attack();
    //event IsAttack AttackInfor;
    bool Die();

    Reward GetReward();

    IEnemy DeepCopy();
    
    /// <summary>
    /// Quest - kill monster
    /// </summary>
    /// <param name="allQuestList">From [gamescene->battlescene]</param>
    public void CallOnKilled(AllQuestList allQuestList);
}

