using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KillMinion : IQuest
{
    public string questName { get; set; }      // 퀘스트 이름
    public string questLine { get; set; }      // 퀘스트 대사
    public string reward { get; set; }         // 퀘스트 보상
    public bool isCompleted { get; set; }      // 퀘스트 완료 여부

    public string monsterName {get; set;}       // 목표 몬스터
    public int requireCount { get; set; }       // 필요 처치 수
    public int currentCount { get; set; }       // 현재 처치 수

    public KillMinion()
    {
        questName = "마을을 위협하는 미니언 처치";
        
        questLine = "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n" +
                    "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                    "모험가인 자네가 좀 처치해주게!\n";
        
        reward = "장비";
        isCompleted = false;
        monsterName = "미니언";
        requireCount = 5;
        currentCount = 0;
    }


}

