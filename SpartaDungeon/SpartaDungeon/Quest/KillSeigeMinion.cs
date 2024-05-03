using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class KillSeigeMinion : IQuest
{
    public string questName { get; set; }     
    public string questLine { get; set; }      
    public string reward { get; set; }        
    public bool isCompleted { get; set; }
    public string monsterName { get; set; }      
    public int requireCount { get; set; }      
    public int currentCount { get; set; }
    public bool isAccept { get; set; }         // 수락했는가 ? true : false  


    public KillSeigeMinion()
    {
        questName = "대포미니언를 보고 우울감을 느끼는 자";

        questLine = "  자네 그거 아는가...\n" +
                    "  미니언들이 이제 대포를 끌고 왔다네...\n" +
                    "  심지어 능숙하게 다루고, 엄청 잘 쏘더군...\n" +
                    "  난 대포를 못 다뤄서, 이번 대포 사격 시험에 떨어졌는데...\n" +
                    "  하아.. 벌써 4번 떨어졌는데.. 미니언은...\n" +
                    "  아무튼 마을의 평화에 위협은 되니, 좀 잡아주면 안 되겠는가..?\n" +
                    "  조금 많이...\n";

        reward = "조잡한 대포\n  200 Gold\n  30 Exp";
        isCompleted = false;

        monsterName = "대포미니언";
        requireCount = 7;
        currentCount = 0;
        isAccept = false;
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
            Console.WriteLine($"  대포미니언 처치 {requireCount}/{currentCount}");
            return 0;
        }
    }
    public void RewardToQuest(Inventory inventory, IPlayer player)
    {
        inventory.items.Add(new Item("조잡한 대포", 15, 0, 0, "대포 미니언이 가지고 있던 대포이다.", "공격력", false, false, 1));
        player.GetGold(200);
        player.GainExperience(30);
        player.LevelUp();
    }


}

