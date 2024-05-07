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

    public bool AttackTurn
    {
        get { return attackTurn; }

        set { attackTurn = value; }
    }

    public bool isTurnEnd { get; set; } = false;

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
    private int enemyNumber = 0;


    public BattleScene(AllQuestList allQuestList)
    {
        this.AllQuestList = allQuestList;
    }

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
    public void InitSettingDungeon(IPlayer player, int floor)
    {
        //isEnding = false; //test용
        tempPlayerHealth = player.CurrentHp;
        attackTurn = true;
        isEnding = false;
        isTurnEnd = false;
        turnCount = 0;
        dieEnemyCount = 0;

        if (competeEnemys.Count >= 0)
            competeEnemys.Clear();

        if(floor < 6)
        {
            enemyCount = random.Next(floor + 1, (floor + 1) * 2);
            for (int i = 0; i < enemyCount; i++)
            {
                //Select Enemy Deep Copy and Add
                IEnemy choiceEnemy = enemys[random.Next(0, enemys.Count)].DeepCopy();
                competeEnemys.Add(choiceEnemy);
            }
        }
        else
        {
            competeEnemys.Add(new Baron().DeepCopy());
        }       

        enemyNumber = competeEnemys.Count;
    }



    public int[] RandomAttack()
    {
        Random random = new Random();
        List<int> shuffledIndexes = Enumerable.Range(0, competeEnemys.Count).OrderBy(i => random.Next()).ToList();
        List<int> selectedIndexes = shuffledIndexes.Take(2).ToList();
        return (int[])selectedIndexes.ToArray();
    }

    /// <summary>
    /// Enemys and Player Fight 
    /// </summary>
    /// <param name="player"> Player Data </param>
    /// <param name="choice"> Player InputKey Number</param>
    /// <author> ChoiYunHwa </author>
    public void BattleDungeon(IPlayer player, int choice, int skillDamge)
    {   
        if (attackTurn) //Player Turn
        {
            //int currentAtk = (int)Math.Ceiling(player.Atk);
            if (skillDamge == 0)
            {
                playerAttackDamage = player.Attack();
                //random.Next(currentAtk - 1, currentAtk + 1); //Player Attack Range -1 ~ +1        

                //Console.WriteLine($"플레이어의 데미지!!{playerAttackDamage}");
            }
            else
            {
                playerAttackDamage = skillDamge;
            }

            if (choice != 0)
            {
                orderEnemy = competeEnemys[choice - 1];

                orderEnemy.currentHP -= playerAttackDamage;

                if (orderEnemy.currentHP <= 0)
                {
                    dieEnemyCount++;
                    //competeEnemys[turnCount].CallOnKilled(AllQuestList);
                    orderEnemy.currentHP = 0;
                    orderEnemy.isDead = true;
                }
            }
            else
            {
                orderEnemy = competeEnemys[choice];

                orderEnemy.currentHP -= playerAttackDamage;

                if (orderEnemy.currentHP <= 0)
                {
                    enemyNumber--;
                    dieEnemyCount++;
                    orderEnemy.currentHP = 0;
                    orderEnemy.isDead = true;
                }
            }
        }
        else // Enemy's Turn
        {
                turnCount++;
            if (turnCount <= enemyNumber)
            {
                currentEnemy = competeEnemys[turnCount - 1];
                if (!competeEnemys[turnCount - 1].Die())
                {
                    orderEnemy = competeEnemys[turnCount - 1];
                    int enemyDamage = orderEnemy.Attack();
                    player.CurrentHp -= enemyDamage;

                    if (player.CurrentHp <= 0)
                    {
                        player.CurrentHp = 0;
                        isEnding = true;
                    }
                    //if (competeEnemys[turnCount].currentHP <= 0)
                    //{
                    //    dieEnemyCount++;
                    //    competeEnemys[turnCount].CallOnKilled(AllQuestList);
                    //    competeEnemys[turnCount].currentHP = 0;
                    //    competeEnemys[turnCount].isDead = true;
                    //}                  
                }
                else
                {
                    //turnCount++;
                    return;
                }
                if(turnCount == enemyCount)
                    isTurnEnd = true;
            }
            else
            {
                //turnCount = 0;
                attackTurn = true;
            }
        }

        if (dieEnemyCount == competeEnemys.Count)
        {  
            isEnding = true;
        }
    }
}



