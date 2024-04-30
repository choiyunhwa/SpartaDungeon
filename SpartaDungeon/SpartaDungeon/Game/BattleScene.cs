using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class BattleScene
{
    private Random random = new Random();

    public List<IEnemy> enemys = new List<IEnemy>(); //Enemy의 정보
    public List<IEnemy> competeEnemys = new List<IEnemy>(); //던전에 출몰하는 Enemy
    public int enemyCount { get; set; }

    private int dieEnemyCount = 0;

    private bool attackTurn = true; // false : Monster Turn, true : Player Turn

    public bool AttackTurn
    {
        get { return attackTurn; }

        set { attackTurn = value; }
    }

    private bool isAttack = true;

    public bool IsAttack
    {
        get { return isAttack; }
    }

    private int playerAttackDamage = 0;

    public int PlayerAttackDamage
    {
        get { return playerAttackDamage; }
    }

    int turnCount = 0;
    public IEnemy orderEnemy;
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
        enemyCount = random.Next(1, 5);

        for (int i = 0; i < enemyCount; i++)
        {
            //현재 참조 상태로 변경 해야함
            IEnemy choiceEnemy = enemys[random.Next(0, enemys.Count)]; //몬스터 종류가 담겨있는 곳에서 하나씩 뽑아냄 

            competeEnemys.Add(choiceEnemy);
        }
    }

    /// <summary>
    /// Monsters and Player Fight 
    /// </summary>
    public void BattleDungeon(IPlayer player, int choice)
    {
        tempPlayerHealth = player.CurrentHp;
        List<IEnemy> tempEnemyHealth = competeEnemys;

        int currentAtk = (int)Math.Ceiling(player.Atk);
        playerAttackDamage = random.Next(currentAtk - 1, currentAtk + 1); //Player Attack Range -1 ~ +1         

        if (attackTurn) //Player Turn
        {
            //int choice = int.Parse(Console.ReadLine());           

            if (choice != 0)
            {
                orderEnemy = competeEnemys[choice - 1];

                orderEnemy.currentHP -= playerAttackDamage;

                //attackTurn = false;
            }
        }
        else // Enemy's Turn
        {

            if(turnCount < competeEnemys.Count)
            {
                if (!competeEnemys[turnCount].Die())
                {
                    orderEnemy = competeEnemys[turnCount];
                    int enemyDamage = orderEnemy.Attack();
                    player.CurrentHp -= enemyDamage;


                    if(player.CurrentHp <= 0)
                    {
                        player.CurrentHp = 0;
                    }


                    if (competeEnemys[turnCount].currentHP <= 0)
                    {
                        dieEnemyCount++;
                        competeEnemys[turnCount].currentHP = 0;
                        competeEnemys[turnCount].isDead = true;
                    }

                    //if (turnCount == competeEnemys.Count)
                    //{
                    //    turnCount = 0;
                    //    attackTurn = false;
                    //}
                }
                turnCount++;
            }
            else
            {
                turnCount = 0;
                attackTurn = true;
            }
            
        }

        if (dieEnemyCount == competeEnemys.Count)
        {
            isAttack = false;
        }

        //BattleResult(player);
    }

    /// <summary>
    /// Show the results after the battle
    /// </summary>
    public bool BattleResult(IPlayer player)
    {
        if (player.CurrentHp > 0)
        {
            //Utility에 tempHealth 정보, player.health 정보, dieEnemyCount 정보 보냄

            return true;
        }
        else
        {
            //Utility에 정보를 보냄
            return false;
        }
    }
}

