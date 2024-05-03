using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IQuest
{
    string questName { get; set; }      // 퀘스트 이름
    string questLine { get; set; }      // 퀘스트 대사
    string reward { get; set; }         // 퀘스트 보상
    bool isCompleted { get; set; }      // 퀘스트 완료 여부
    string monsterName { get; set; }     // 목표 몬스터
    int requireCount { get; set; }       // 필요 처치 수
    int currentCount { get; set; }       // 현재 처치 수
    bool isAccept { get; set; }         // 수락했는가 ? true : false

    public void OnKilledEnemy(string killedMonsterName); //죽은 몬스터의 이름을 가져와 퀘스트 받은 몬스터와 비교하는 함수
    public void OnItemEquipped(string itemName);       //  장비 착용시 호출되는 함수. 장비 착용 퀘스트에서 사용
    public void OnLevelUp();         // 레벨업을 할 시 호출되는 함수. 레벨업 하는 퀘스트에서 사용
    public void CompleteQuest(); // 퀘스트를 완료 상태로 바꾸는 함수
    public int CheckQuest(); // 퀘스트를 완료했는가 확인하는 함수
}
