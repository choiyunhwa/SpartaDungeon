using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Reward
{
    public int gold { get; set; }
    public int exp { get; set; }

    /// <summary>
    /// Give a Reward
    /// </summary>
    /// <param name="monsters"> 승리한 전투에서 만난 몬스터들의 정보 </param>>
    /// <author> KwonSinWook </author>>
    public void GetReward(List<IEnemy> monsters, IPlayer player)
    {
        int totalGold = 0;
        int totalExp = 0;

        foreach (var monster in monsters)
        {
            Reward reward = monster.GetReward();    // 각 몬스터들의 보상(돈과 경험치)을 가져와서 저장.

            totalGold += reward.gold;
            totalExp += reward.exp;
        }

        Console.WriteLine($" 획득한 골드 : {totalGold} Gold");
        Console.WriteLine($" 획득한 경험치 : {totalExp} Exp");

        player.GetGold(totalGold);
        player.GainExperience(totalExp);
    }
}

