using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class BattleScene
{
    private Random random = new Random();

    public List<IEnemy> enemys = new List<IEnemy>(); //Enemy Information
    public List<IEnemy> competeEnemys = new List<IEnemy>(); //던전에 출몰하는 Enemy
    public int enemyCount { get; set; }

    private int dieEnemyCount = 0;

    private bool attackTurn = true; // false : Monster Turn, true : Player Turn

    private AllQuestList AllQuestList;

    public BattleScene(AllQuestList allQuestList)
    {
        this.AllQuestList = allQuestList;
    }

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
        isEnding = false; //test용
        tempPlayerHealth = player.CurrentHp;
        enemyCount = random.Next(1, 5);

        if (competeEnemys.Count > 0)
            competeEnemys.Clear();

        for (int i = 0; i < enemyCount; i++)
        {
            //Select Enemy Deep Copy and Add
            IEnemy choiceEnemy = enemys[random.Next(0, enemys.Count)].DeepCopy(); 
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


        if (attackTurn) //Player Turn
        {   
            if (choice != 0)
            {
                orderEnemy = competeEnemys[choice - 1];

                orderEnemy.currentHP -= playerAttackDamage;
                
                if(orderEnemy.currentHP <= 0)
                {
                    dieEnemyCount++;
                    competeEnemys[turnCount].CallOnKilled(AllQuestList);
                    orderEnemy.currentHP = 0;
                    orderEnemy.isDead = true;
                }               
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
                        competeEnemys[turnCount].CallOnKilled(AllQuestList);
                        competeEnemys[turnCount].currentHP = 0;
                        competeEnemys[turnCount].isDead = true;
                    }                  
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
    }
}



