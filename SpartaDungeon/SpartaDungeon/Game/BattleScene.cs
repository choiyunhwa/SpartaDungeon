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

    public bool isEnding { get; set; } = false;

    public int turnCount { get; set; } = 0;
    public IEnemy orderEnemy;
    public IEnemy currentEnemy;
    public int tempPlayerHealth { get; set; } = 0;

    /// <summary>
    /// Add Enemy Informaion Setting 
    /// </summary>
    /// <author> ChoiYunHwa </author>
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
    /// <param name="player"> Player Data </param>
    /// <author> ChoiYunHwa </author>
    public void InitSettingDungeon(IPlayer player)
    {
        tempPlayerHealth = player.CurrentHp;
        enemyCount = random.Next(1, 5);

        for (int i = 0; i < enemyCount; i++)
        {
            //현재 참조 상태로 변경 해야함
            IEnemy choiceEnemy = enemys[random.Next(0, enemys.Count)].DeepCopy(); //몬스터 종류가 담겨있는 곳에서 하나씩 뽑아냄 


            competeEnemys.Add(choiceEnemy);
        }
    }

    /// <summary>
    /// Enemys and Player Fight 
    /// </summary>
    /// <param name="player"> Player Data </param>
    /// <param name="choice"> Player InputKey Number</param>
    /// <author> ChoiYunHwa </author>
    public void BattleDungeon(IPlayer player, int choice)
    {
        List<IEnemy> tempEnemyHealth = competeEnemys;

        int currentAtk = (int)Math.Ceiling(player.Atk);
        playerAttackDamage = random.Next(currentAtk - 1, currentAtk + 1); //Player Attack Range -1 ~ +1         

        //Console.WriteLine($" attackTurn :   {attackTurn}    choice : {choice}");

        if (attackTurn) //Player Turn
        {   
            if (choice != 0)
            {
                //Console.WriteLine("플레이어 단계!!\n");
                orderEnemy = competeEnemys[choice - 1];

                orderEnemy.currentHP -= playerAttackDamage;
                
                if(orderEnemy.currentHP <= 0)
                {
                    dieEnemyCount++;
                    orderEnemy.currentHP = 0;
                    orderEnemy.isDead = true;
                }               

                //attackTurn = false;
            }
        }
        else // Enemy's Turn
        {

            if (turnCount <= competeEnemys.Count)
            {
                if (!competeEnemys[turnCount].Die())
                {
                    currentEnemy = competeEnemys[turnCount];
                    orderEnemy = competeEnemys[turnCount];
                    int enemyDamage = orderEnemy.Attack();
                    player.CurrentHp -= enemyDamage;


                    if (player.CurrentHp <= 0)
                    {
                        player.CurrentHp = 0;
                        isEnding = true;
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
                else
                {
                    turnCount++;
                    return;
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
            isEnding = true;
        }

        //BattleResult(player);
    }
}



