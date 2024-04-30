using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class BattleScene
{
    private Random random = new Random();

    public List<IEnemy> enemys = new List<IEnemy>();
    public List<IEnemy> competeEnemys = new List<IEnemy>();
    public int enemyCount { get; set; }

    private int dieEnemyCount = 0;

    private bool attackTurn = true; // false : Monster Turn, true : Player Turn

    private int tempPlayerHealth = 0;
    private int tempEnemyHealth = 0;


    public void SettingEnemyData()
    {
        enemys.Add(new Minion());
        enemys.Add(new Voidling());
        enemys.Add(new SiegeMinion());
        enemys.Add(new Dragon());
    }


    /// <summary>
    /// Setting the number of monsters ( 1 ~ 4 )
    /// </summary>
    public void SettingMonster()
    {
        enemyCount = random.Next(1, 5); //나타낼 몬스터의 숫자

        for (int i = 0; i < enemyCount; i++)
        {
            IEnemy choiceEnemy = enemys[random.Next(0, enemys.Count)]; //어딘가 담겨져있는 몬스터 종류 

            competeEnemys.Add(choiceEnemy);
        }
    }

    /// <summary>
    /// Monsters and Player Fight
    /// </summary>
    public void BattleDungeon(IPlayer player) 
    {
        tempPlayerHealth = player.CurrentHp;
        List<IEnemy>tempEnemyHealth = competeEnemys;

        int currentAtk = (int)Math.Ceiling(player.Atk);
        int attack = random.Next(currentAtk - 1, currentAtk + 1); //Player Attack Range -1 ~ +1 

        while (dieEnemyCount == competeEnemys.Count || player.CurrentHp <= 0)
        {

            if (attackTurn)
            {
                int choice = int.Parse(Console.ReadLine());                               

                competeEnemys[choice].currentHP -= attack;

                attackTurn = false;
            }
            else
            {
                foreach (var enemy in competeEnemys)
                {
                    if (!enemy.Die())
                    {
                        int enemyDamage = enemy.Attack();
                        player.CurrentHp -= enemyDamage;

                        if (player.CurrentHp <= 0)
                            break;


                        if (enemy.currentHP <= 0)
                        {
                            dieEnemyCount++;
                            enemy.currentHP = 0;
                            enemy.isDead = true;
                        }
                        //Utility Message에 정보 보내기

                    }
                }
                attackTurn = true;
            }


        }

        BattleResult(player);
    }

    /// <summary>
    /// Show the results after the battle
    /// </summary>
    public void BattleResult(IPlayer player) //Player player
    {
        //if(player.health > 0)
        //{
        //    //Utility에 tempHealth 정보, player.health 정보, dieEnemyCount 정보 보냄
        //}
        //else
        //{
        //    //Utility에 정보를 보냄
        //}
    }
}

