using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class TryLevelUp : IQuest
{
    public string questName { get; set; }
    public string questLine { get; set; }
    public string reward { get; set; }
    public bool isCompleted { get; set; }
    public string monsterName { get; set; }     
    public int requireCount { get; set; }       
    public int currentCount { get; set; }
    public bool isAccept { get; set; }         // 수락했는가 ? true : false    

    public TryLevelUp()
    {
        questName = "더욱 더 강해지기";

        questLine = "  모든 사람은 어떠한 경험을 가지며 살아간다네.\n" +
                    "  그 경험을 통해 깨닫는 것이 있고, 이를 통해 더욱 단단해지지.\n" +
                    "  이는 모험가에게도 마찬가지이며, 너에게도 통하는 말이겠지.\n" +
                    "  경험을 쌓도록 하세. 너를 더 강해지게 해줄 것이니.\n";

        reward = "경험치";
        isCompleted = false;
        monsterName = "";
        requireCount = 0;
        currentCount = 0;
        isAccept = false;
    }

    public void OnKilledEnemy(string KilledMonsterName) { }

    public void OnLevelUp()         // 레벨업을 하면 퀘스트 완료
    {
        CompleteQuest();
    }

    public void OnItemEquipped(string itemName) { }

    public void CompleteQuest()
    {
        isCompleted = true;
    }

    public int CheckQuest()
    {
        if (isCompleted)
        {
            Console.WriteLine("퀘스트가 완료되었습니다.");
            return 1;
        }

        else
        {
            Console.WriteLine("퀘스트가 아직 완료되지 않았습니다.\n");
            return 0;
        }
    }
}

