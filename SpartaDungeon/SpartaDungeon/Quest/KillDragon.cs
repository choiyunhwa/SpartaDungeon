using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class KillDragon : IQuest
{
    public string questName { get; set; }       // 퀘스트 이름
    public string questLine { get; set; }       // 퀘스트 대사
    public string reward { get; set; }          // 퀘스트 보상
    public bool isCompleted { get; set; }       // 퀘스트 완료 여부

    public string monsterName { get; set; }     // 목표 몬스터
    public int requireCount { get; set; }       // 필요 처치 수
    public int currentCount { get; set; }       // 현재 처치 수


    public KillDragon()
    {
        questName = "던전 근처의 새끼 드래곤 처치";

        questLine = "저기요! 당신 지금 던전으로 가려고 하는 겁니까?\n" +
                    "무슨 생각입니까! 지금 던전 근처 상황을 모르시는 겁니까?\n" +
                    "이유는 모르겠지만, 새끼 드래곤이 던전 근처를 활개치며 돌아다니고 있습니다.\n" +
                    "마을에서 새끼 드래곤에게 현상금을 걸었으니, 조금만 기다리면 상급 모험가들이 토벌할 겁니다.\n" +
                    "아니면 당신도 현상금을 노리는 겁니까?\n";

        reward = "골드";          //보상 부분을 어떻게 설정할지 모르겠어서 목표 보상만 적어두겠습니다.
        monsterName = "드래곤";
        requireCount = 1;
        currentCount = 0;
        isCompleted = false;
    }

    public void OnKilledEnemy(string KilledMonsterName)
    {
        if (KilledMonsterName == monsterName)       // 죽인 몬스터의 이름과 퀘스트 몬스터의 이름이 같다면
        {
            currentCount++;         // 현재 처치 수 증가
        }

        if (requireCount == currentCount) // 처치 수 증가로 인해 목표 처치 수와 같아졌다면
        {
            CompleteQuest();        // 퀘스트 완료 함수 호출
        }
    }

    public void CompleteQuest()
    {
        isCompleted = true;
    }

    public int CheckQuest()
    {
        if (isCompleted)        //퀘스트가 깨졌다면 완료 문구와 함께 보상 데이터 전달 (자료형은 이후 바뀔 수 있음)
        {
            Console.WriteLine("퀘스트가 완료되었습니다.");
            return 1;       // 현재 어떻게 아이템 보상을 전달할지 몰라서 임의로 reutrn 1 값을 설정
        }

        else
        {
            Console.WriteLine("퀘스트가 아직 완료되지 않았습니다.\n");
            Console.WriteLine($"드래곤 처치 {requireCount}/{currentCount}");
            return 0;
        }
    }
}

//위의 주석은 다른 Kill{Enumy} 퀘스트 스크립트 설명과 동일합니다.
