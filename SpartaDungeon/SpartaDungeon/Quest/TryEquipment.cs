using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class TryEquipment : IQuest
{
    public string questName { get; set; }    
    public string questLine { get; set; }     
    public string reward { get; set; }         
    public bool isCompleted { get; set; }
    public string monsterName { get; set; }    
    public int requireCount { get; set; }       
    public int currentCount { get; set; }
    public bool isAccept { get; set; }         // 수락했는가 ? true : false    
    public bool isRewarded { get; set; }       // 보상을 받은 퀘스트인가?


    public delegate void CompleteQuestHandler(bool isCompleted);


    public TryEquipment()
    {
        questName = "장비를 장착해보자";
        
        questLine = "  자네! 장비는 제대로 착용하고 있는가?\n" + 
                    "  모험가에게 장비는 목숨과도 같다네!\n" + 
                    "  모험가가 장비를 착용하지 않는 것은 죽겠다는 거와 다름없지!\n" + 
                    "  장비가 생기는 대로 착용해 보는 것을 권한다네!";
        
        reward = "15 Exp";
        isCompleted = false;
        monsterName = "";
        requireCount = 0;
        currentCount = 0;
        isAccept = false;
        isRewarded = false;
    }

    public void OnKilledEnemy(string KilledMonsterName) { }     // 장비 착용 퀘스트이기 때문에 이 메소드는 비워두었습니다.

    public void OnItemEquipped(string itemName)        // 아무 장비 착용시 퀘스트 완료
    {
        CompleteQuest();
    }

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
            Console.WriteLine("  퀘스트가 아직 완료되지 않았습니다.\n");
            return 0;
        }
    }


    public void RewardToQuest(Inventory inventory, IPlayer player)
    {
        player.GainExperience(15);
        player.LevelUp();
        isRewarded = true;
    }

}

