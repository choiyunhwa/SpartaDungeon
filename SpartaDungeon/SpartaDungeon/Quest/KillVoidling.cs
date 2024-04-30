using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon.Quest
{
    internal class KillVoidling
    {
        public string questName { get; set; }      // 퀘스트 이름
        public string questLine { get; set; }      // 퀘스트 대사
        public string reward { get; set; }         // 퀘스트 보상
        public bool isCompleted { get; set; }      // 퀘스트 완료 여부

        public string monsterName { get; set; }       // 목표 몬스터
        public int requireCount { get; set; }       // 필요 처치 수
        public int currentCount { get; set; }       // 현재 처치 수

        public KillVoidling()
        {
            questName = "정체를 모르는 불길한 공허충 잡기";

            questLine = "최근에 가끔씩 멀쩡하던 공간에 갑자기 금이가서 마치 찢기는 듯한 현상이 나타난다고 하더군\n" +
                        "그 찢긴 부분을 들여다 본 사람들에 의하면, 보이는 건 공허밖에 없었다고 하네.\n" +
                        "하지만 가끔씩 그 속에서 정체 모를 벌레들이 나오기도 한다더군\n" +
                        "다행스럽게도 강하지는 않아서 토벌을 할 수 있을 정도라 하니, 만일 보게 된다면 처치하는게 좋을 걸세.\n" +
                        "자네도 모험가니 말이야.\n";
            
            reward = "경험치";
            isCompleted = false;

            monsterName = "공허충";
            requireCount = 5;
            currentCount = 0;
        }



    }
}
