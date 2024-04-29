using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    public class BattleScene
    {
        private Random random = new Random();
        
        public List<int> enemys = new List<int>(); //Enemy로 변경 해야함
        public int enemyCount { get; set; }

        private int dieEnemyCount = 0;

        private bool attackTurn = true; // false : Monster Turn, true : Player Turn

        private int tempPlayerHealth = 0;
        private int tempEnemyHealth = 0;

        /// <summary>
        /// Setting the number of monsters ( 1 ~ 4 )
        /// </summary>
        public void SettingMonster()
        {
            enemyCount =  random.Next(1,5); //나타낼 몬스터의 숫자
            
            for(int i = 0; i < enemyCount; i++) 
            { 
                int choiceEnemy = random.Next(1, 5); //어딘가 담겨져있는 몬스터 종류

                enemys.Add(choiceEnemy);
            }
        }

        /// <summary>
        /// Monsters and Player Fight
        /// </summary>
        public void BattleDungeon() //Player player
        {
            //tempPlayerHealth = player.health;
            //tempEnemyHealth = Enemy.health;

            while (true) /*dieEnemyCount == enemys.Count || player.health <= 0*/
            {
                //int attack = Math.Ceiling(random.Next(player.attack - 1, player.attack + 1)); //Player Attack Range -1 ~ +1 

                if(attackTurn)
                {
                    int choice = int.Parse(Console.ReadLine()); //차후 Utility에서 변경                    
                    
                    //enemys[choice].  //enemy 데미지 입히기

                    attackTurn = false;
                }
                else
                {
                    //foreach (var enemy in enemys)
                    //{
                    //    if (!enemy.isDead)
                    //    {
                    //        int enemyDamage = enemy.Attack();
                    //        player.health -= enemyDamage;

                    //        //Utility Message에 정보 보내기
                    //    }
                    //}
                    attackTurn = true;
                }               
            }

            BattleResult();
        }

        /// <summary>
        /// Show the results after the battle
        /// </summary>
        public void BattleResult() //Player player
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
}
