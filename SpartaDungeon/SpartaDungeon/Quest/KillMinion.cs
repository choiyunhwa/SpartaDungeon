using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KillMinion : IQuest
{
    public string questName { get; set; }      
    public string questLine { get; set; }    
    public string reward { get; set; }        
    public bool isCompleted { get; set; }      
    public string monsterName {get; set;}       
    public int requireCount { get; set; }      
    public int currentCount { get; set; }
    public bool isAccept { get; set; }         // 수락했는가 ? true : false
    public bool isRewarded { get; set; }       // 보상을 받은 퀘스트인가?

    public KillMinion()
    {
        questName = "마을을 위협하는 미니언 처치";
        
        questLine = "  이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n" +
                    "  마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                    "  모험가인 자네가 좀 처치해주게!\n";
        
        reward = "175 Gold\n  20 Exp";
        isCompleted = false;
        monsterName = "미니언";
        requireCount = 5;
        currentCount = 0;
        isAccept = false;
        isRewarded = false;
    }

    public void OnKilledEnemy(string KilledMonsterName)
    {
        if (KilledMonsterName == monsterName)
        {
            currentCount++;
        }

        if (requireCount == currentCount)
        {
            CompleteQuest();
        }
    }

    public void OnItemEquipped(string itemName) { }
    public void OnLevelUp() { }


    public void CompleteQuest()
    {
        isCompleted = true;
        isAccept = false;
        CheckQuest();
    }

    public int CheckQuest()
    {
        if (isCompleted)
        {
            Console.WriteLine("  퀘스트가 완료되었습니다.");
            return 1;
        }

        else
        {
            Console.WriteLine("  퀘스트가 아직 완료되지 않았습니다.");
            Console.WriteLine($"  미니언 처치 {requireCount}/{currentCount}");
            return 0;
        }
    }


    public void RewardToQuest(Inventory inventory, IPlayer player)
    {
        player.GetGold(175);
        player.GainExperience(20);
        player.LevelUp();
        isRewarded = true;
    }



}

