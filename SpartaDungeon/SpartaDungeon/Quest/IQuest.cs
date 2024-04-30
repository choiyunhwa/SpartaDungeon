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

    public void OnKilledEnemy(string KilledMonsterName); //죽은 몬스터의 이름을 가져와 퀘스트 받은 몬스터와 비교하는 함수
                                                         //이를 IEnemy 인터페이스를 상속받은 여러 Enemy 클래스의 Die() 함수에서 실행시킬지
                                                         //아니면 전투 부분에서 따로 실행시킬지 모르겠습니다.
    public void CompleteQuest(); // 만일 필요 몬스터 처치수를 달성했으면 호출되는 함수.
    public int CheckQuest(); // 퀘스트를 완료했는가 확인하는 함수
}
